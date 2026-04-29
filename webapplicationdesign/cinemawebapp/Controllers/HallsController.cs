using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cinemawebapp.Controllers
{
    public class HallsController : Controller
    {
        private readonly IHallService _hallService;
        private readonly ICinemaService _cinemaService;
        public HallsController(IHallService hallService, ICinemaService cinemaService)
        {
            _hallService = hallService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index() => View(await _hallService.GetAllWithCinemaAsync());

        public async Task<IActionResult> Details(int id)
        {
            var hall = await _hallService.GetByIdWithCinemaAsync(id);
            if (hall == null) return NotFound();
            return View(hall);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Cinemas = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hall hall)
        {
            if (ModelState.IsValid) { await _hallService.AddAsync(hall); return RedirectToAction(nameof(Index)); }
            ViewBag.Cinemas = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name", hall.CinemaId);
            return View(hall);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hall = await _hallService.GetByIdAsync(id);
            if (hall == null) return NotFound();
            ViewBag.Cinemas = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name", hall.CinemaId);
            return View(hall);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hall hall)
        {
            if (id != hall.Id) return NotFound();
            if (ModelState.IsValid) { await _hallService.UpdateAsync(hall); return RedirectToAction(nameof(Index)); }
            ViewBag.Cinemas = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name", hall.CinemaId);
            return View(hall);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hall = await _hallService.GetByIdWithCinemaAsync(id);
            if (hall == null) return NotFound();
            return View(hall);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _hallService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
