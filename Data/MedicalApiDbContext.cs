using Lab5LKPZ.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5LKPZ.Data
{
    public class MedicalApiDbContext : DbContext
    {
        private static MedicalApiDbContext _instance;
        private static readonly object LockObject = new object();

         public MedicalApiDbContext(DbContextOptions options) : base(options)
        {
        }

        private MedicalApiDbContext()
        {
        }

        // Метод для отримання єдиного екземпляру MedicalApiDbContext
        public static MedicalApiDbContext Instance
        {
            get
            {
                // Перевірка, чи екземпляр вже створено
                if (_instance == null)
                {
                    // Заблокувати потік, щоб уникнути створення декількох екземплярів
                    lock (LockObject)
                    {
                        // Double-Check Locking
                        if (_instance == null)
                        {
                            _instance = new MedicalApiDbContext();
                        }
                    }
                }

                return _instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=PC305\\SQLEXPRESS;database=MedCard;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAppointmentModel>()
          .HasOne(m => m.MedicalRecord)
          .WithMany(r => r.Appointments)
          .HasForeignKey(m => m.PatientID);

            modelBuilder.Entity<DoctorPatientRelation>()
           .HasKey(dpr => new { dpr.DoctorID, dpr.PatientID });

            modelBuilder.Entity<DoctorPatientRelation>()
                .HasOne(dpr => dpr.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(dpr => dpr.DoctorID);

            modelBuilder.Entity<DoctorPatientRelation>()
                .HasOne(dpr => dpr.Patient)
                .WithMany(p => p.Doctors)
                .HasForeignKey(dpr => dpr.PatientID);
            // інші конфігурації можна додати тут

            base.OnModelCreating(modelBuilder);

            
        }
        public DbSet<Model.MedicalRecordModel> MedicalRecords { get; set; }
        public DbSet<Model.MedicalAppointmentModel> MedicalAppointment { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<DoctorPatientRelation> DoctorPatientRelation { get; set; }
    }
}
