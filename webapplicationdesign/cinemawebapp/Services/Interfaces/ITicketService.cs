using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllWithDetailsAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket?> GetByIdWithDetailsAsync(int id);
        Task<List<Ticket>> GetByCustomerAsync(string customerName);
        Task<List<Ticket>> GetByUserIdAsync(string userId);
        Task<List<string>> GetTakenSeatsByScreeningAsync(int screeningId);
        Task<Dictionary<int, List<string>>> GetTakenSeatsMapAsync();
        /// <summary>Returns error message or null on success.</summary>
        Task<string?> BuyTicketAsync(int screeningId, string seatNumber, string ticketType, decimal price, string customerName, string? userId);
        Task<string?> BuyMultipleTicketsAsync(int screeningId, string seatNumbers, string ticketType, decimal price, string customerName, DateTime screeningStartTime, string? userId);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
        Task DeleteByUserIdAsync(string userId);
    }
}
