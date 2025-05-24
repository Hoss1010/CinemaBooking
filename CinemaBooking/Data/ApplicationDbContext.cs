using CinemaBooking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CinemaBooking.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Movies> Movie { get; set; }
        public DbSet<Cinemas> Cinema { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actors> actors { get; set; }
        public DbSet<ActorMovie> actorMovies { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<ApplicationUserOTP> ApplicationUserOTPs { get; set; }
        // Detracted
        public ApplicationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RQOB028;Initial Catalog=CinemaBooking;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
