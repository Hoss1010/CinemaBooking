using CinemaBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movies> Movie { get; set; }
        public DbSet<Cinemas> Cinema { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RQOB028;Initial Catalog=CinemaBooking;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
