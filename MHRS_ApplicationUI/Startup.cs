using AutoMapper;
using MHRS_ApplicationDataAccessLayer;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.Mappings;
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

namespace MHRS_ApplicationUI
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
            //aspnet core un connection string baðlantýsýný yapabilmesi için
            //servislere dbcontexti eklemek gerekir
            services.AddDbContext<MyContext>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60); //oturum kapanma süresi
            });
            services.AddIdentity<AppUser,AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.@";
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();
            //Mapleme
            services.AddAutoMapper(typeof(Maps));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseStaticFiles(); //wwwroot klasörüne eriþebilmek için

            app.UseRouting(); //route mekanizma
            app.UseSession(); //sessionu kullanmak için
            app.UseAuthorization(); //[Authorize] attribute için
            app.UseAuthentication(); //login ve logout iþlemleri için

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
