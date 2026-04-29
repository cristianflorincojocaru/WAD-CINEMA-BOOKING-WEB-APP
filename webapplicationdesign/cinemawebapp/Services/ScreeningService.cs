using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _repo;
        private readonly IMovieRepository _movieRepo;
        public ScreeningService(IScreeningRepository repo, IMovieRepository movieRepo)
        {
            _repo = repo;
            _movieRepo = movieRepo;
        }

        public Task<List<Screening>> GetAllWithDetailsAsync() => _repo.GetAllWithDetailsAsync();
        public Task<Screening?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Screening?> GetByIdWithDetailsAsync(int id) => _repo.GetByIdWithDetailsAsync(id);
        public Task<List<Screening>> GetByDayAsync(int dayIndex, int? cinemaId) => _repo.GetByDayAsync(dayIndex, cinemaId);

        public async Task<string?> CreateAsync(Screening screening)
        {
            var movie = await _movieRepo.GetByIdAsync(screening.MovieId);
            if (movie == null) return "Movie not found.";

            var conflict = await _repo.HasConflictAsync(screening.HallId, screening.StartTime, movie.DurationMinutes);
            if (conflict) return "This hall is already booked during that time.";

            await _repo.AddAsync(screening);
            return null;
        }

        public async Task<string?> UpdateAsync(Screening screening)
        {
            var movie = await _movieRepo.GetByIdAsync(screening.MovieId);
            if (movie == null) return "Movie not found.";

            var conflict = await _repo.HasConflictAsync(screening.HallId, screening.StartTime, movie.DurationMinutes, screening.Id);
            if (conflict) return "This hall is already booked during that time.";

            await _repo.UpdateAsync(screening);
            return null;
        }

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
