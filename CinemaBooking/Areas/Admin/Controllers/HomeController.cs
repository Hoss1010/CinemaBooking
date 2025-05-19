using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _Context = new();
        public IActionResult Index()
        {
            var movies = _Context.Movie.Include(e => e.Cinema).Include(e => e.Categories);

            return View(movies.ToList());
        }
        public IActionResult NotFoundPage()
        {

            return View();
        }
    }
}
