using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cinemawebapp.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly IScreeningService _screeningService;
        private readonly IMovieService _movieService;
        private readonly IHallService _hallService;

        public ScreeningsController(IScreeningService screeningService, IMovieService movieService, IHallService hallService)
        {
            _screeningService = screeningService;
            _movieService = movieService;
            _hallService = hallService;
        }

        public async Task<IActionResult> Index() =>
            View(await _screeningService.GetAllWithDetailsAsync());

        public async Task<IActionResult> Details(int id)
        {
            var screening = await _screeningService.GetByIdWithDetailsAsync(id);
            if (screening == null) return NotFound();
            ViewBag.TicketsSold = screening.Tickets.Count;
            return View(screening);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Movies = new SelectList(await _movieService.GetAllAsync(), "Id", "Title");
            ViewBag.Halls = new SelectList(await _hallService.GetAllWithCinemaAsync(), "Id", "Name");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Screening screening)
        {
            if (ModelState.IsValid)
            {
                var error = await _screeningService.CreateAsync(screening);
                if (error == null) return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", error);
            }
            ViewBag.Movies = new SelectList(await _movieService.GetAllAsync(), "Id", "Title", screening.MovieId);
            ViewBag.Halls = new SelectList(await _hallService.GetAllWithCinemaAsync(), "Id", "Name", screening.HallId);
            return View(screening);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var screening = await _screeningService.GetByIdAsync(id);
            if (screening == null) return NotFound();
            ViewBag.Movies = new SelectList(await _movieService.GetAllAsync(), "Id", "Title", screening.MovieId);
            ViewBag.Halls = new SelectList(await _hallService.GetAllWithCinemaAsync(), "Id", "Name", screening.HallId);
            return View(screening);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Screening screening)
        {
            if (id != screening.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var error = await _screeningService.UpdateAsync(screening);
                if (error == null) return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", error);
            }
            ViewBag.Movies = new SelectList(await _movieService.GetAllAsync(), "Id", "Title", screening.MovieId);
            ViewBag.Halls = new SelectList(await _hallService.GetAllWithCinemaAsync(), "Id", "Name", screening.HallId);
            return View(screening);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var screening = await _screeningService.GetByIdWithDetailsAsync(id);
            if (screening == null) return NotFound();
            return View(screening);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _screeningService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
