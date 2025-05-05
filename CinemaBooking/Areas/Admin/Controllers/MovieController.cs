using CinemaBooking.Data;
using CinemaBooking.Models;
using CinemaBooking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _Context = new();

        public IActionResult Index()
        {
            var movies = _Context.Movie.Include(e => e.Cinema)
                .Include(e => e.Categories).Select(e => new ProductWithCategoryWithBrandVM()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    ImgUrl = e.ImgUrl,
                    TrailerUrl = e.TrailerUrl,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Cinema = e.Cinema,
                    Categories = e.Categories,
                    IsAvailable = e.IsAvailable
                }); 

            return View(movies.ToList());
        }
        public IActionResult Create()
        {
            var categories = _Context.Categories;
            var Cinema = _Context.Cinema;
            CategoryWithCinemaVM categoryWithcinemaVM = new()
            {
                movies = new Movies(),
                Categories = categories.ToList(),
                Cinema = Cinema.ToList()
            };
            return View(categoryWithcinemaVM);
        }
        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            //ModelState.Remove("movie.Cinema");
            //ModelState.Remove("movie.Category");
            if (!ModelState.IsValid)
            {
                CategoryWithCinemaVM categoryWithcinemaVM = new()
                {
                    movies = new Movies(),
                    Categories = _Context.Categories.ToList(),
                    Cinema = _Context.Cinema.ToList()
                };
                return View(categoryWithcinemaVM);
            } 
            _Context.Movie.Add(movie);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult NotFoundPage()
        {

            return View();
        }
    }
}
