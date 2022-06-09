using AutoMapper;
using MHRS_ApplicationEntityLayer.Mappings;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationBusinessLayer.Concretes;
using MHRS_ApplicationBusinessLayer.EMailService;
using MHRS_ApplicationDataAccessLayer;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Concretes;
using MHRS_ApplicationEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHRS303BusinessLayer.Concretes;
using AutoMapper.Extensions.ExpressionMapping;

namespace MHRS303UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Aspnet mvc core'un connection string baðlantýsýný yapabilmesi için 
            //servislere dbcontexti eklemek gerekiyor.
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
            });

            //IEmailSenderService gördüðün zaman 
            //EmailSenderManager isimli nesneden türet

            services.AddSingleton<IEmailSenderService, EmailSenderManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IClinicService, ClinicManager>();
            services.AddScoped<IDistrictService, DistrictManager>();
            services.AddScoped<IHospitalClinicService, HospitalClinicManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IAppointmentHourService, AppointmentHourManager>();
            services.AddScoped<IHospitalService, HospitalManager>();
            services.AddScoped<IDenemeService, DenemeManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();  // bu en aşağıda kalsın hep

            //services.AddControllersWithViews();
            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );
            services.AddRazorPages();//razor sayfaları için
            services.AddMvc(); //TODO: bunsuz yapabilir misin? 
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60); //oturum süresi
            });
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.AllowedUserNameCharacters =
               "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.-@";
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

            //Mapleme
            //services.AddAutoMapper(typeof(Maps));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping(); //expressionları maple (filterın maplenmesini sağlar)
                cfg.AddProfile(typeof(Maps));
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<AppRole> roleManager, ICityService cityManager, IDistrictService districtManager,
            IClinicService clinicManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // wwwroot klasörüne eriþebilmek için

            app.UseRouting(); // route mekanizma
            app.UseSession(); // Session'ý kullanmak için

            app.UseAuthentication(); // Login ve Logout iþlemleri için 
            app.UseAuthorization(); // [Authorize] attribute için



            //Proje ilk ayaða kalktýðýnda sistemdeki roller oluþsun
            CreateDefaultData.CreateData.Create(roleManager, env, cityManager, districtManager, clinicManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Doctor}/{controller=Account}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
