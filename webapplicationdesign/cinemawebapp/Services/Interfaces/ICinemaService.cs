using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<List<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task UpdateAsync(Cinema cinema);
        Task DeleteAsync(int id);
    }
}
