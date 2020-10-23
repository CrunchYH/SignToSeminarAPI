using Microsoft.EntityFrameworkCore;
using SignToSeminarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Context
{
    public class SignToSeminarDBContext : DbContext
    {
        // All entities need to be "listed" here or the Entity Framework don't "know" about them
        public DbSet<Speaker> Speakers { set; get; }
        public DbSet<Seminar> Seminars { set; get; }
        public DbSet<Day> Days { set; get; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSeminar> UserSeminars {get; set; }
        

        public SignToSeminarDBContext(DbContextOptions<SignToSeminarDBContext> options) : base(options)
        {
            //Test dependency injection
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The database connection, the simple but bad way to include it
            //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=STSDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship using Fluent API

            // Configuring the one-to-many relationship between tables Seminar and Speaker
            modelBuilder.Entity<Seminar>()
                .HasOne<Speaker>(s => s.speaker)
                .WithMany(s => s.seminars)
                .HasForeignKey(s => s.SeminarOfSpeakerId);

            //Configuring the one-to-many relationship between tables Seminar and Day
            modelBuilder.Entity<Seminar>()
                .HasOne<Day>(s => s.day )
                .WithMany(d => d.seminars)
                .HasForeignKey(d => d.SeminarOfDayId);

            // Composite Primary Key for joining the tables User and Seminar with a many-to-many relationship
            modelBuilder.Entity<UserSeminar>().HasKey(sc => new { sc.userId, sc.seminarId });



        }
    }

}
