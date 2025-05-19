using CinemaBooking.Data;
using CinemaBooking.Models;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _Context = new();
        private readonly  ICategoryRepository _categoryRepository ;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var Categories = _categoryRepository.Get();
            return View(Categories.ToList());
        }
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetOne(e => e.Id == id);

            if (category is not null)
            {
                return View(category);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
             _categoryRepository.Update(category);
            await _categoryRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
           var category= _categoryRepository.GetOne(e => e.Id == id);
            if (category is not null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage","Home");

        }

    }
}
