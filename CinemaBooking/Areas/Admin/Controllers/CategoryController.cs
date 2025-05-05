using CinemaBooking.Data;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _Context = new();
        public IActionResult Index()
        {
            var Categories =_Context.Categories;
            return View(Categories.ToList());
        }
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _Context.Categories.Add(category);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var category = _Context.Categories.Find(id);

            if (category is not null)
            {
                return View(category);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _Context.Categories.Update(category);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
           var category= _Context.Categories.Find(id);
            if (category is not null)
            {
                _Context.Remove(category);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage","Home");

        }

    }
}
