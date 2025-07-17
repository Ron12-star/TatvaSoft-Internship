using Microsoft.EntityFrameworkCore;
using Mission.Entities.Entities;
using System;

namespace Mission.Entities.Context
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // ✅ fixed typo

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "admin@tatvasoft.com",
                UserType = "Admin",
                Password = "Tatv@123",
                PhoneNumber = "5454848484",
                CreateDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
