using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IPromotionService _promotionService;
        public PromotionsController(IPromotionService promotionService) { _promotionService = promotionService; }

        public async Task<IActionResult> Index() => View(await _promotionService.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Promotion promotion)
        {
            if (ModelState.IsValid) { await _promotionService.AddAsync(promotion); return RedirectToAction(nameof(Index)); }
            return View(promotion);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Promotion promotion)
        {
            if (id != promotion.Id) return NotFound();
            if (ModelState.IsValid) { await _promotionService.UpdateAsync(promotion); return RedirectToAction(nameof(Index)); }
            return View(promotion);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _promotionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
