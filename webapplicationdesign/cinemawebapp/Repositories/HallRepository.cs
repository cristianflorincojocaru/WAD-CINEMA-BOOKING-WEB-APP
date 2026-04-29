using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly AppDbContext _context;
        public HallRepository(AppDbContext context) { _context = context; }

        public Task<List<Hall>> GetAllAsync() => _context.Halls.ToListAsync();
        public Task<List<Hall>> GetAllWithCinemaAsync() => _context.Halls.Include(h => h.Cinema).ToListAsync();
        public async Task<Hall?> GetByIdAsync(int id) => await _context.Halls.FindAsync(id);
        public Task<Hall?> GetByIdWithCinemaAsync(int id) =>
            _context.Halls.Include(h => h.Cinema).FirstOrDefaultAsync(h => h.Id == id);

        public async Task AddAsync(Hall hall) { _context.Halls.Add(hall); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Hall hall) { _context.Halls.Update(hall); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            if (hall != null) { _context.Halls.Remove(hall); await _context.SaveChangesAsync(); }
        }
    }
}
