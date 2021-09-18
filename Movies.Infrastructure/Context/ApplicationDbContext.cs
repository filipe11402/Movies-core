using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure.Entities;

namespace Movies.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public ApplicationDbContext(DbContextOptions options) :  base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(property => property.Name)
                .HasMaxLength(250);

            modelBuilder.Entity<Movie>()
                .Property(property => property.ReleaseYear)
                .HasMaxLength(4);

            modelBuilder.Entity<Movie>()
                .Property(property => property.Synopsis)
                .HasMaxLength(250);
        }
    }
}
