using Microsoft.EntityFrameworkCore;
using SMS_REST_API.Models;

namespace SMS_REST_API.DataAccess
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions<CityContext> options) : base(options)
        {
        }

        public DbSet<CityModel> CityDbSet { get; set; }
        //public DbSet<CityDataModel> CityData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>().ToTable("CityModel");
            //modelBuilder.Entity<CityDataModel>().ToTable("CityData");
        }
    }
}