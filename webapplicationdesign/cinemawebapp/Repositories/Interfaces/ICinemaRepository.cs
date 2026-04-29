using cinemawebapp.Models;

namespace cinemawebapp.Repositories.Interfaces
{
    public interface ICinemaRepository
    {
        Task<List<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task UpdateAsync(Cinema cinema);
        Task DeleteAsync(int id);
    }
}
