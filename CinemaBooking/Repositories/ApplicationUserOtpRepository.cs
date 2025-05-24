using CinemaBooking.Data;
using CinemaBooking.Models;
using CinemaBooking.Repositories.IRepositories;

namespace CinemaBooking.Repositories
{
    public class ApplicationUserOtpRepository : Repository<ApplicationUserOTP>, IApplicationUserOtpRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserOtpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }

}
