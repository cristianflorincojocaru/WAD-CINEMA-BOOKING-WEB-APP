using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;
        public CinemasController(ICinemaService cinemaService) { _cinemaService = cinemaService; }

        public async Task<IActionResult> Index() => View(await _cinemaService.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (ModelState.IsValid) { await _cinemaService.AddAsync(cinema); return RedirectToAction(nameof(Index)); }
            return View(cinema);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (id != cinema.Id) return NotFound();
            if (ModelState.IsValid) { await _cinemaService.UpdateAsync(cinema); return RedirectToAction(nameof(Index)); }
            return View(cinema);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
