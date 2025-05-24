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
                   // ImgUrl = e.ImgUrl.ToString(),

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
            var Actors = _Context.actors;
            CategoryWithCinemaVM categoryWithcinemaVM = new()
            {
                movies = new Movies(),
                Categories = categories.ToList(),
                Cinema = Cinema.ToList(),
                actors= Actors.ToList()

            };
            return View(categoryWithcinemaVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryWithCinemaVM movie, IFormFile ImgUrl)
        {
            ModelState.Remove("movies.actorMovies");
            ModelState.Remove("ImgUrl");

            CategoryWithCinemaVM categoryWithCinemaVM = new()
            {
                movies = movie.movies,
                Categories = _Context.Categories.ToList(),
                Cinema = _Context.Cinema.ToList(),
                actors = _Context.actors.ToList()
            };

            if (ModelState.IsValid && ImgUrl != null && ImgUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await ImgUrl.CopyToAsync(stream);
                }

                movie.movies.ImgUrl = fileName;

                _Context.Movie.Add(movie.movies);
                await _Context.SaveChangesAsync();


                if (movie.movies.Id > 0 && movie.ActorsId != null && movie.ActorsId.Any())
                {
                    foreach (var actorId in movie.ActorsId)
                    {
                        _Context.actorMovies.Add(new ActorMovie
                        {
                            MovieId = movie.movies.Id,
                            ActorId = actorId
                        });
                    }

                    await _Context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoryWithCinemaVM);
        }



        
        public IActionResult Edit(int id)
        {
            var movie = _Context.Movie.Find(id);
            if(movie is not null)
            {
                CategoryWithCinemaVM categoryWithcinemaVM = new()
                {
                    movies = movie,
                    Categories = _Context.Categories.ToList(),
                    Cinema = _Context.Cinema.ToList()
                };
                return View(categoryWithcinemaVM);
            }
            return RedirectToAction("NotFoundPage","Home");
        }
        [HttpPost]
        public IActionResult Edit(CategoryWithCinemaVM movie, IFormFile ImgUrl)
        {
         
            var movieInDb= _Context.Movie.AsNoTracking().FirstOrDefault(e => e.Id == movie.movies.Id);
            ModelState.Remove("ImgUrl");
            ModelState.Remove("movies.actorMovies");
            if (ModelState.IsValid && movieInDb != null)
            {
                if (ImgUrl != null && ImgUrl.Length > 0)
                {
                    // Add new img to wwwroot
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        ImgUrl.CopyToAsync(stream);
                    }
                    //Delete old img from wwwroot
                    var OldFileName = movieInDb.ImgUrl;
                    var OldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", OldFileName);
                    if (System.IO.File.Exists(OldPath))
                    {
                        System.IO.File.Delete(OldPath);
                    }
                    // Update img in Db
                    movie.movies.ImgUrl = fileName;

                    
                }
                else
                {
                    //save the old img
                    movie.movies.ImgUrl= movieInDb.ImgUrl;
                }
                _Context.Movie.Update(movie.movies);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            
            CategoryWithCinemaVM categoryWithcinemaVM = new()
            {
                movies = movie.movies,
                Categories = _Context.Categories.ToList(),
                Cinema = _Context.Cinema.ToList()
            };
            return View(categoryWithcinemaVM);

        }
        public IActionResult Delete(int id)
        {
            var movie = _Context.Movie.Find(id);

            if (movie is not null)
            {
                var oldFileName = movie.ImgUrl;
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", oldFileName);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                _Context.Remove(movie);
                _Context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        public IActionResult NotFoundPage()
        {

            return View();
        }
    }
}

