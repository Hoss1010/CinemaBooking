using System.Diagnostics;
using System.Numerics;
using CinemaBooking.Data;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Areas.Customer.Controllers   
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string search, int page = 1)
        {
            IQueryable<Movies> movie = _context.Movie;
            var Movie = _context.Movie.ToList();
            if (search is not null)
            {
                Movie = Movie.Where(d => d.Name.Contains(search)).ToList();
                ViewBag.search = search;
            }

            if (Movie.ToList().Count() == 0)
            {
                return RedirectToAction(nameof(NotFoundPage));
            }

            var numOfDoctors = Movie.Count();
            var numOfPages = Math.Ceiling(numOfDoctors / 5.0);

            ViewBag.numOfPages = numOfPages;
            Movie = Movie.Skip((page - 1) * 5).Take(5).ToList();

            return View(Movie.ToList());
        }
        public IActionResult Details(int id)
        {
            var movie = _context.Movie
                .Include(m => m.Categories)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFoundPage();

            return View(movie);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
