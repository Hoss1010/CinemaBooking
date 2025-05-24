using CinemaBooking.Data;
using CinemaBooking.Models;
using CinemaBooking.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }

}
