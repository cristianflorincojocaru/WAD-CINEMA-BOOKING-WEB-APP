using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITicketService _ticketService;

        public ProfileController(UserManager<ApplicationUser> um, ITicketService ts)
        {
            _userManager = um; _ticketService = ts;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var tickets = (await _ticketService.GetByUserIdAsync(user!.Id)).ToList();
            ViewBag.Tickets = tickets;
            return View(user);
        }
    }
}