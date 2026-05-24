using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITicketService _ticketService;

        public UsersController(UserManager<ApplicationUser> um, ITicketService ts)
        {
            _userManager = um; _ticketService = ts;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _ticketService.DeleteByUserIdAsync(id);
            await _userManager.DeleteAsync(user);
            TempData["ToastSuccess"] = "User deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}