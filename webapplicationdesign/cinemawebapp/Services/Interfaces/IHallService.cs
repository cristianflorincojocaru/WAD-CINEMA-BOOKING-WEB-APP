using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface IHallService
    {
        Task<List<Hall>> GetAllAsync();
        Task<List<Hall>> GetAllWithCinemaAsync();
        Task<Hall?> GetByIdAsync(int id);
        Task<Hall?> GetByIdWithCinemaAsync(int id);
        Task AddAsync(Hall hall);
        Task UpdateAsync(Hall hall);
        Task DeleteAsync(int id);
    }
}
