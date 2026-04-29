using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) { _context = context; }

        public Task<List<Ticket>> GetAllWithDetailsAsync() =>
            _context.Tickets
                .Include(t => t.Screening).ThenInclude(s => s.Movie)
                .ToListAsync();

        public async Task<Ticket?> GetByIdAsync(int id) => await _context.Tickets.FindAsync(id);

        public Task<Ticket?> GetByIdWithDetailsAsync(int id) =>
            _context.Tickets
                .Include(t => t.Screening).ThenInclude(s => s.Movie)
                .FirstOrDefaultAsync(t => t.Id == id);

        public Task<List<Ticket>> GetByCustomerAsync(string customerName) =>
            _context.Tickets
                .Include(t => t.Screening).ThenInclude(s => s.Movie)
                .Include(t => t.Screening).ThenInclude(s => s.Hall).ThenInclude(h => h.Cinema)
                .Where(t => t.CustomerName == customerName)
                .OrderByDescending(t => t.PurchasedAt)
                .ToListAsync();

        public Task<List<Ticket>> GetByUserIdAsync(string userId) =>
            _context.Tickets
                .Include(t => t.Screening).ThenInclude(s => s.Movie)
                .Include(t => t.Screening).ThenInclude(s => s.Hall)
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.PurchasedAt)
                .ToListAsync();

        public Task<bool> IsSeatTakenAsync(int screeningId, string seatNumber) =>
            _context.Tickets.AnyAsync(t => t.ScreeningId == screeningId && t.SeatNumber == seatNumber);

        public Task<List<string>> GetTakenSeatsByScreeningAsync(int screeningId) =>
            _context.Tickets
                .Where(t => t.ScreeningId == screeningId)
                .Select(t => t.SeatNumber)
                .ToListAsync();

        public Task<Dictionary<int, List<string>>> GetTakenSeatsMapAsync() =>
            _context.Tickets
                .GroupBy(t => t.ScreeningId)
                .ToDictionaryAsync(g => g.Key, g => g.Select(t => t.SeatNumber).ToList());

        public async Task AddAsync(Ticket ticket) { _context.Tickets.Add(ticket); await _context.SaveChangesAsync(); }
        public async Task AddRangeAsync(IEnumerable<Ticket> tickets) { _context.Tickets.AddRange(tickets); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Ticket ticket) { _context.Tickets.Update(ticket); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var t = await _context.Tickets.FindAsync(id);
            if (t != null) { _context.Tickets.Remove(t); await _context.SaveChangesAsync(); }
        }

        public async Task DeleteByUserIdAsync(string userId)
        {
            var tickets = _context.Tickets.Where(t => t.UserId == userId);
            _context.Tickets.RemoveRange(tickets);
            await _context.SaveChangesAsync();
        }
    }
}
