using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentHour> AppointmentHours { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<HospitalClinic> HospitalClinics { get; set; }
        public virtual DbSet<Deneme> Deneme { get; set; }
        protected override void OnModelCreating (ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            //builder.Entity<City>().HasIndex(c => new { c.PlateCode }.IsUnique(true));


            //builder.Entity<District>().HasOne(d => d.City) //bire
            //    .WithMany(c => c.Districts) //çok
            //    .HasForeignKey(d => d.CityId) //ne üzerinden
            //    .OnDelete(DeleteBehavior.NoAction); //hangi davranış


            base.OnModelCreating(builder);
        }

    }
}
