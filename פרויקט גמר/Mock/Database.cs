using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    public class Database:DbContext,IContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserWorkoutPlan> UserWorkoutPlans { get; set; }
        public DbSet<WorkoutVideo> WorkoutVideos { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=GymDB;trusted_connection=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // הגדרת קשרים בטבלת UserWorkoutPlan
            modelBuilder.Entity<UserWorkoutPlan>()
                .HasOne(u => u.User)  // קשר עם טבלת משתמשים
                .WithMany()  // קשר מרובה-ליחיד
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction); // לא ננקטת שום פעולה על מחיקה

            modelBuilder.Entity<UserWorkoutPlan>()
                .HasOne(u => u.WorkoutVideo)  // קשר עם טבלת סרטונים
                .WithMany()  // קשר מרובה-ליחיד
                .HasForeignKey(u => u.VideoId)
                .OnDelete(DeleteBehavior.NoAction); // לא ננקטת שום פעולה על מחיקה
        }
    }
}
