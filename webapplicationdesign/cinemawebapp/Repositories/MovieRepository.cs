using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) { _context = context; }

        public Task<List<Movie>> GetAllAsync() => _context.Movies.ToListAsync();
        public async Task<Movie?> GetByIdAsync(int id) => await _context.Movies.FindAsync(id);
        public Task<List<Movie>> GetNowShowingAsync() => _context.Movies.Where(m => !m.IsUpcoming).ToListAsync();
        public Task<List<Movie>> GetUpcomingAsync() => _context.Movies.Where(m => m.IsUpcoming).ToListAsync();

        public async Task AddAsync(Movie movie) { _context.Movies.Add(movie); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Movie movie) { _context.Movies.Update(movie); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null) { _context.Movies.Remove(movie); await _context.SaveChangesAsync(); }
        }
    }
}
