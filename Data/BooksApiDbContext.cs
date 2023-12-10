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

            optionsBuilder.UseSqlServer("server=PC305\\SQLEXPRESS;database=Medcard;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Model.MedicalRecordModel> MedicalRecords { get; set; }
        

    }
}
