using AnimalWebApi.Entities;
using AnimalWebApi.Seeder;
using Microsoft.EntityFrameworkCore;

namespace AnimalWebApi.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedData());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animals { get; set; }
    }
}
