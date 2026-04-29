using cinemawebapp.Models;

namespace cinemawebapp.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllWithDetailsAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket?> GetByIdWithDetailsAsync(int id);
        Task<List<Ticket>> GetByCustomerAsync(string customerName);
        Task<List<Ticket>> GetByUserIdAsync(string userId);
        Task<bool> IsSeatTakenAsync(int screeningId, string seatNumber);
        Task<List<string>> GetTakenSeatsByScreeningAsync(int screeningId);
        Task<Dictionary<int, List<string>>> GetTakenSeatsMapAsync();
        Task AddAsync(Ticket ticket);
        Task AddRangeAsync(IEnumerable<Ticket> tickets);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
        Task DeleteByUserIdAsync(string userId);
    }
}
