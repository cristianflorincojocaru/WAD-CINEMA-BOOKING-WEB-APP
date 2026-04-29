using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly AppDbContext _context;
        public ScreeningRepository(AppDbContext context) { _context = context; }

        public Task<List<Screening>> GetAllWithDetailsAsync() =>
            _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .ToListAsync();

        public async Task<Screening?> GetByIdAsync(int id) => await _context.Screenings.FindAsync(id);

        public Task<Screening?> GetByIdWithDetailsAsync(int id) =>
            _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<List<Screening>> GetByDayAsync(int dayIndex, int? cinemaId)
        {
            var all = await _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Hall).ThenInclude(h => h.Cinema)
                .ToListAsync();

            return all
                .Where(s => (int)s.StartTime.DayOfWeek == dayIndex)
                .Where(s => !cinemaId.HasValue || s.Hall.CinemaId == cinemaId.Value)
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public async Task<bool> HasConflictAsync(int hallId, DateTime start, int durationMinutes, int? excludeId = null)
        {
            var endTime = start.AddMinutes(durationMinutes);
            return await _context.Screenings
                .Include(s => s.Movie)
                .Where(s => s.HallId == hallId && (excludeId == null || s.Id != excludeId))
                .AnyAsync(s => start < s.StartTime.AddMinutes(s.Movie.DurationMinutes) && endTime > s.StartTime);
        }

        public async Task AddAsync(Screening screening) { _context.Screenings.Add(screening); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Screening screening) { _context.Screenings.Update(screening); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var s = await _context.Screenings.FindAsync(id);
            if (s != null) { _context.Screenings.Remove(s); await _context.SaveChangesAsync(); }
        }
    }
}
