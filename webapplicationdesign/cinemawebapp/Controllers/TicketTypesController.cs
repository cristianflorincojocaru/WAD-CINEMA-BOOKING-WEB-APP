using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TicketTypesController : Controller
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypesController(ITicketTypeService ticketTypeService) { _ticketTypeService = ticketTypeService; }

        public async Task<IActionResult> Index() =>
            View(await _ticketTypeService.GetAllAsync());

        public IActionResult Create() => View(new TicketType());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketType t)
        {
            if (ModelState.IsValid) { await _ticketTypeService.AddAsync(t); return RedirectToAction(nameof(Index)); }
            return View(t);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var t = await _ticketTypeService.GetByIdAsync(id);
            if (t == null) return NotFound();
            return View(t);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketType t)
        {
            if (id != t.Id) return NotFound();
            if (ModelState.IsValid) { await _ticketTypeService.UpdateAsync(t); return RedirectToAction(nameof(Index)); }
            return View(t);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketTypeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
