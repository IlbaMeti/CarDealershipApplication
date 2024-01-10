using Microsoft.EntityFrameworkCore;

namespace CarDealershipApplication.Data.Models
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<CarDealership> CarDealerships { get; set;}
        public DbSet<Car> Cars { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed
        }
    }
}
