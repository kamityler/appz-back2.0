using Lab5LKPZ.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5LKPZ.Data
{
    public class BooksApiDbContext : DbContext
    {
        public BooksApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public BooksApiDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-SR4JFTJ\\MSSQLSERVER01;database=Medcard;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAppointmentModel>()
          .HasOne(m => m.MedicalRecord)
          .WithMany(r => r.Appointments)
          .HasForeignKey(m => m.PatientID);

            // інші конфігурації можна додати тут

            base.OnModelCreating(modelBuilder);

            
        }
        public DbSet<Model.MedicalRecordModel> MedicalRecords { get; set; }
        public DbSet<Model.MedicalAppointmentModel> MedicalAppointment { get; set; }


    }
}
