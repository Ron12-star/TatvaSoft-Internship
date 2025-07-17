using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Context
{
    public class MissionDbContextFactory : IDesignTimeDbContextFactory<MissionDbContext>
    {
        public MissionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MissionDbContext>();

            // ✅ Use your actual connection string here
            var connectionString = "Host=localhost;Database=Mission;Username=postgres;Password=Ronak@123";
            optionsBuilder.UseNpgsql(connectionString); // Or .UseSqlServer() if using SQL Server

            return new MissionDbContext(optionsBuilder.Options);
        }
    }
}
