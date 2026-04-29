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
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            IMovieService movieService,
            ICinemaService cinemaService,
            IScreeningService screeningService,
            ITicketService ticketService,
            IPromotionService promotionService,
            ITicketTypeService ticketTypeService,
            UserManager<IdentityUser> userManager)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
            _screeningService = screeningService;
            _ticketService = ticketService;
            _promotionService = promotionService;
            _ticketTypeService = ticketTypeService;
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

        public async Task<IActionResult> Movies()
        {
            var movies = await _movieService.GetNowShowingAsync();
            return View(movies);
        }

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

            var takenSeats = await _ticketService.GetTakenSeatsByScreeningAsync(screeningId);
            ViewBag.TakenSeats = takenSeats;
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
                return RedirectToAction(nameof(SelectSeat), new { screeningId });
            }

            TempData["Bought"] = $"Seat {seatNumber} confirmed!";
            return RedirectToAction(nameof(Profile));
        }

        [Authorize]
        public async Task<IActionResult> MyTickets()
        {
            var userId = _userManager.GetUserId(User);
            var tickets = await _ticketService.GetByUserIdAsync(userId!);
            ViewBag.TicketTypes = await _ticketTypeService.GetActiveAsync();
            return View(tickets);
        }

        public async Task<IActionResult> Cinemas()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return View(cinemas);
        }

        public async Task<IActionResult> Tickets(int? screeningId, string? ticketType)
        {
            var screenings = await _screeningService.GetAllWithDetailsAsync();
            var takenSeatsMap = await _ticketService.GetTakenSeatsMapAsync();

            ViewBag.Cinemas = await _cinemaService.GetAllAsync();
            ViewBag.TakenSeatsMap = takenSeatsMap;
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
            var screeningStartTime = screening?.StartTime ?? DateTime.MinValue;

            var error = await _ticketService.BuyMultipleTicketsAsync(screeningId, seatNumbers, ticketType, price, customerName, screeningStartTime, userId);
            if (error != null)
            {
                TempData["SeatError"] = error;
                return RedirectToAction(nameof(Tickets), new { screeningId });
            }

            TempData["Bought"] = "Reservation confirmed!";
            return RedirectToAction(nameof(Profile));
        }

        public IActionResult Tarife() => View();

        public async Task<IActionResult> Upcoming()
        {
            var movies = await _movieService.GetUpcomingAsync();
            return View(movies);
        }

        public async Task<IActionResult> Promotions()
        {
            var promotions = await _promotionService.GetActiveAsync();
            return View(promotions);
        }

        public async Task<IActionResult> PromoDetails(int id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return View(promo);
        }

        public IActionResult About() => View();

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);
            var tickets = await _ticketService.GetByUserIdAsync(userId!);
            ViewBag.Bought = TempData["Bought"];
            return View(tickets);
        }
    }
}
