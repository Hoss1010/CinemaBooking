using CinemaBooking.Data;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
        public class CinemaController : Controller
        {
            private readonly ApplicationDbContext _Context = new();
            public IActionResult Index()
            {
                var Cinema = _Context.Cinema;
                return View(Cinema.ToList());
            }
            public IActionResult Create()
            {
                return View(new Cinemas());
            }

            [HttpPost]
            public IActionResult Create(Cinemas cinemas)
            {
                _Context.Cinema.Add(cinemas);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        public IActionResult Edit(int id)
        {
            var Cinema = _Context.Cinema.Find(id);

            if (Cinema is not null)
            {
                return View(Cinema);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult Edit(Cinemas cinemas)
        {
            _Context.Cinema.Update(cinemas);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var Cinema = _Context.Cinema.Find(id);
            if (Cinema is not null)
            {
                _Context.Remove(Cinema);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage", "Home");

        }


    }
    
}
