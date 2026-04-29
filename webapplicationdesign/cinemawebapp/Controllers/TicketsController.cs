using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cinemawebapp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IScreeningService _screeningService;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketsController(ITicketService ticketService, IScreeningService screeningService, UserManager<IdentityUser> userManager)
        {
            _ticketService = ticketService;
            _screeningService = screeningService;
            _userManager = userManager;
        }

        private async Task<List<SelectListItem>> GetScreeningSelectItemsAsync(int? selectedId = null)
        {
            var screenings = await _screeningService.GetAllWithDetailsAsync();
            return screenings.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Movie.Title} — {s.StartTime:dd MMM yyyy HH:mm} — {s.Hall.Name}",
                Selected = s.Id == selectedId
            }).ToList();
        }

        public async Task<IActionResult> Index() => View(await _ticketService.GetAllWithDetailsAsync());

        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _ticketService.GetByIdWithDetailsAsync(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        public async Task<IActionResult> Create(int? screeningId)
        {
            ViewBag.Screenings = await GetScreeningSelectItemsAsync(screeningId);
            return View(new Ticket { ScreeningId = screeningId ?? 0 });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.PurchasedAt = DateTime.UtcNow;
                ticket.UserId = _userManager.GetUserId(User);
                await _ticketService.AddAsync(ticket);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Screenings = await GetScreeningSelectItemsAsync(ticket.ScreeningId);
            return View(ticket);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            ViewBag.Screenings = await GetScreeningSelectItemsAsync(ticket.ScreeningId);
            return View(ticket);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id) return NotFound();
            if (ModelState.IsValid) { await _ticketService.UpdateAsync(ticket); return RedirectToAction(nameof(Index)); }
            ViewBag.Screenings = await GetScreeningSelectItemsAsync(ticket.ScreeningId);
            return View(ticket);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetByIdWithDetailsAsync(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}