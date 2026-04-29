using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        public TicketService(ITicketRepository repo) { _repo = repo; }

        public Task<List<Ticket>> GetAllWithDetailsAsync() => _repo.GetAllWithDetailsAsync();
        public Task<Ticket?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Ticket?> GetByIdWithDetailsAsync(int id) => _repo.GetByIdWithDetailsAsync(id);
        public Task<List<Ticket>> GetByCustomerAsync(string customerName) => _repo.GetByCustomerAsync(customerName);
        public Task<List<Ticket>> GetByUserIdAsync(string userId) => _repo.GetByUserIdAsync(userId);
        public Task<List<string>> GetTakenSeatsByScreeningAsync(int screeningId) => _repo.GetTakenSeatsByScreeningAsync(screeningId);
        public Task<Dictionary<int, List<string>>> GetTakenSeatsMapAsync() => _repo.GetTakenSeatsMapAsync();
        public Task AddAsync(Ticket ticket) => _repo.AddAsync(ticket);
        public Task UpdateAsync(Ticket ticket) => _repo.UpdateAsync(ticket);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task DeleteByUserIdAsync(string userId) => _repo.DeleteByUserIdAsync(userId);

        public async Task<string?> BuyTicketAsync(int screeningId, string seatNumber, string ticketType, decimal price, string customerName, string? userId)
        {
            if (await _repo.IsSeatTakenAsync(screeningId, seatNumber))
                return $"Seat {seatNumber} was just taken. Please choose another.";

            await _repo.AddAsync(new Ticket
            {
                ScreeningId = screeningId,
                SeatNumber = seatNumber,
                TicketType = ticketType,
                Price = price,
                PurchasedAt = DateTime.UtcNow,
                CustomerName = customerName,
                UserId = userId
            });
            return null;
        }

        public async Task<string?> BuyMultipleTicketsAsync(int screeningId, string seatNumbers, string ticketType, decimal price, string customerName, DateTime screeningStartTime, string? userId)
        {
            if (ticketType == "Couples Friday" && screeningStartTime.DayOfWeek != DayOfWeek.Friday)
                return "Couples Friday is only available on Fridays.";

            decimal pricePerSeat = ticketType switch
            {
                "Family Pack" => Math.Round(99m / 4, 2),
                "Couples Friday" => Math.Round(55m / 2, 2),
                _ => price
            };

            var seatList = seatNumbers.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => s.Trim()).Take(5).ToList();

            var tickets = new List<Ticket>();
            foreach (var seat in seatList)
            {
                if (await _repo.IsSeatTakenAsync(screeningId, seat)) continue;
                tickets.Add(new Ticket
                {
                    ScreeningId = screeningId,
                    SeatNumber = seat,
                    TicketType = ticketType,
                    Price = pricePerSeat,
                    PurchasedAt = DateTime.UtcNow,
                    CustomerName = customerName,
                    UserId = userId
                });
            }

            await _repo.AddRangeAsync(tickets);
            return null;
        }
    }
}
