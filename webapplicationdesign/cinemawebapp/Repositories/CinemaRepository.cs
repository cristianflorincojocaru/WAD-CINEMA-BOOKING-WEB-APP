using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _context;
        public CinemaRepository(AppDbContext context) { _context = context; }

        public Task<List<Cinema>> GetAllAsync() => _context.Cinemas.ToListAsync();
        public async Task<Cinema?> GetByIdAsync(int id) => await _context.Cinemas.FindAsync(id);

        public async Task AddAsync(Cinema cinema) { _context.Cinemas.Add(cinema); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Cinema cinema) { _context.Cinemas.Update(cinema); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null) { _context.Cinemas.Remove(cinema); await _context.SaveChangesAsync(); }
        }
    }
}
