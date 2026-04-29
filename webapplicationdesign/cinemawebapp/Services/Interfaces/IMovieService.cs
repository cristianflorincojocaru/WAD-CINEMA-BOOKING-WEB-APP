using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<List<Movie>> GetNowShowingAsync();
        Task<List<Movie>> GetUpcomingAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}
