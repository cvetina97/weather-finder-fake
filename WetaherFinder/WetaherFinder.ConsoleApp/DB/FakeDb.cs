using Microsoft.EntityFrameworkCore;

namespace WetaherFinder.ConsoleApp
{
    public class FakeDb : DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=WeatherFinderDB;Integrated Security=True");
        }
    }
}
