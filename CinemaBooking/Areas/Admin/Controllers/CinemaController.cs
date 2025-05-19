using CinemaBooking.Data;
using CinemaBooking.Models;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        //private readonly ApplicationDbContext _Context = new();
        private readonly ICinemaRepository _cinemaRepository;
        public CinemaController(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        public IActionResult Index()
        {
            var Cinema = _cinemaRepository.Get();
            return View(Cinema.ToList());
        }
        public IActionResult Create()
        {
            return View(new Cinemas());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinemas cinemas)
        {
            await _cinemaRepository.CreateAsync(cinemas);
            await _cinemaRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var Cinema = _cinemaRepository.GetOne(e => e.Id == id);

            if (Cinema is not null)
            {
                return View(Cinema);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cinemas cinemas)
        {
            _cinemaRepository.Update(cinemas);
            await _cinemaRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Cinema = _cinemaRepository.GetOne(e => e.Id == id); ;
            if (Cinema is not null)
            {
                _cinemaRepository.Delete(Cinema);
                await _cinemaRepository.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage", "Home");

        }


    }
    
}
