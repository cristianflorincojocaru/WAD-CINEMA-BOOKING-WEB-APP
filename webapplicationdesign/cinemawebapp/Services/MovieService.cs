using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        public MovieService(IMovieRepository repo) { _repo = repo; }

        public Task<List<Movie>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Movie?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<List<Movie>> GetNowShowingAsync() => _repo.GetNowShowingAsync();
        public Task<List<Movie>> GetUpcomingAsync() => _repo.GetUpcomingAsync();
        public Task AddAsync(Movie movie) => _repo.AddAsync(movie);
        public Task UpdateAsync(Movie movie) => _repo.UpdateAsync(movie);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
