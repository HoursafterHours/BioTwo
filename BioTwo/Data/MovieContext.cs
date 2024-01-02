using BioTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BioTwo.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Salon>().ToTable("Salon");
            modelBuilder.Entity<Showing>().ToTable("Showing");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            
        }
    }
}
