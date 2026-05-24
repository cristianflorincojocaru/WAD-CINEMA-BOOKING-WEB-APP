using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cinemawebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        private readonly IScreeningService _screeningService;
        private readonly ITicketService _ticketService;
        private readonly IPromotionService _promotionService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            IMovieService movieService, ICinemaService cinemaService,
            IScreeningService screeningService, ITicketService ticketService,
            IPromotionService promotionService, ITicketTypeService ticketTypeService,
            UserManager<ApplicationUser> userManager)
        {
            _movieService = movieService; _cinemaService = cinemaService;
            _screeningService = screeningService; _ticketService = ticketService;
            _promotionService = promotionService; _ticketTypeService = ticketTypeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var nowShowing = await _movieService.GetNowShowingAsync();
            var comingSoon = await _movieService.GetUpcomingAsync();
            var promotions = await _promotionService.GetActiveAsync();
            ViewBag.ComingSoon = comingSoon;
            ViewBag.Promotions = promotions;
            return View(nowShowing);
        }

        public async Task<IActionResult> Movies() => View(await _movieService.GetNowShowingAsync());

        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        public async Task<IActionResult> Program(int? cinemaId, string? day)
        {
            var cinemas = await _cinemaService.GetAllAsync();
            var dayNames = new[] { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
            var todayDow = (int)DateTime.Today.DayOfWeek;
            var todayIndex = todayDow == 0 ? 6 : todayDow - 1;
            var selectedDay = day ?? dayNames[todayIndex];
            var dayIndex = Array.IndexOf(dayNames, selectedDay.ToUpper());
            var screenings = await _screeningService.GetByDayAsync(dayIndex, cinemaId);
            ViewBag.Cinemas = cinemas;
            ViewBag.SelectedCinemaId = cinemaId ?? (cinemas.Any() ? cinemas.First().Id : (int?)null);
            ViewBag.SelectedDay = selectedDay;
            ViewBag.Bought = TempData["Bought"];
            return View(screenings);
        }

        [Authorize]
        public async Task<IActionResult> SelectSeat(int screeningId)
        {
            var screening = await _screeningService.GetByIdWithDetailsAsync(screeningId);
            if (screening == null) return NotFound();
            ViewBag.TakenSeats = await _ticketService.GetTakenSeatsByScreeningAsync(screeningId);
            ViewBag.SeatError = TempData["SeatError"];
            return View(screening);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> ConfirmTicket(int screeningId, string seatNumber, string ticketType, decimal price)
        {
            var userId = _userManager.GetUserId(User);
            var customerName = User.Identity!.Name ?? "Unknown";
            var error = await _ticketService.BuyTicketAsync(screeningId, seatNumber, ticketType, price, customerName, userId);
            if (error != null)
            {
                TempData["SeatError"] = error;
                TempData["ToastError"] = error;
                return RedirectToAction(nameof(SelectSeat), new { screeningId });
            }
            TempData["ToastSuccess"] = $"Seat {seatNumber} confirmed!";
            return RedirectToAction("Index", "Profile");
        }

        [Authorize]
        public async Task<IActionResult> MyTickets()
        {
            var userId = _userManager.GetUserId(User);
            var tickets = await _ticketService.GetByUserIdAsync(userId!);
            ViewBag.TicketTypes = await _ticketTypeService.GetActiveAsync();
            return View(tickets);
        }

        public async Task<IActionResult> Cinemas() => View(await _cinemaService.GetAllAsync());

        public async Task<IActionResult> Tickets(int? screeningId, string? ticketType)
        {
            var screenings = await _screeningService.GetAllWithDetailsAsync();
            ViewBag.Cinemas = await _cinemaService.GetAllAsync();
            ViewBag.TakenSeatsMap = await _ticketService.GetTakenSeatsMapAsync();
            ViewBag.PreScreeningId = screeningId;
            ViewBag.TicketTypes = await _ticketTypeService.GetActiveAsync();
            ViewBag.PreTicketType = ticketType;
            return View(screenings);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> ConfirmTickets(int screeningId, string seatNumbers, string ticketType, decimal price)
        {
            var userId = _userManager.GetUserId(User);
            var customerName = User.Identity!.Name ?? "Unknown";
            var screening = await _screeningService.GetByIdAsync(screeningId);
            var error = await _ticketService.BuyMultipleTicketsAsync(screeningId, seatNumbers, ticketType, price, customerName, screening?.StartTime ?? DateTime.MinValue, userId);
            if (error != null)
            {
                TempData["SeatError"] = error;
                TempData["ToastError"] = error;
                return RedirectToAction(nameof(Tickets), new { screeningId });
            }
            TempData["ToastSuccess"] = "Reservation confirmed!";
            return RedirectToAction("Index", "Profile");
        }

        public IActionResult Tarife() => View();
        public async Task<IActionResult> Upcoming() => View(await _movieService.GetUpcomingAsync());
        public async Task<IActionResult> Promotions() => View(await _promotionService.GetActiveAsync());

        public async Task<IActionResult> PromoDetails(int id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        public IActionResult About() => View();

        public IActionResult Error(int code)
        {
            if (code == 0) code = HttpContext.Response.StatusCode;
            ViewBag.Code = code;
            return View();
        }
    }
}