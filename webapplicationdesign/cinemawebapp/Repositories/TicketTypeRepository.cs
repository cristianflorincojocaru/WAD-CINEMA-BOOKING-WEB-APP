using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly AppDbContext _context;
        public TicketTypeRepository(AppDbContext context) { _context = context; }

        public Task<List<TicketType>> GetAllAsync() => _context.TicketTypes.ToListAsync();
        public async Task<TicketType?> GetByIdAsync(int id) => await _context.TicketTypes.FindAsync(id);
        public Task<TicketType?> GetByNameAsync(string name) => _context.TicketTypes.FirstOrDefaultAsync(t => t.Name == name);
        public Task<List<TicketType>> GetActiveAsync() => _context.TicketTypes.Where(t => t.IsActive).ToListAsync();

        public async Task AddAsync(TicketType ticketType) { _context.TicketTypes.Add(ticketType); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(TicketType ticketType) { _context.TicketTypes.Update(ticketType); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var t = await _context.TicketTypes.FindAsync(id);
            if (t != null) { _context.TicketTypes.Remove(t); await _context.SaveChangesAsync(); }
        }
    }
}
