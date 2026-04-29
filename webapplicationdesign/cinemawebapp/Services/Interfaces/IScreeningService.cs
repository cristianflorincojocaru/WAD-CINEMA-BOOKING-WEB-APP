using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface IScreeningService
    {
        Task<List<Screening>> GetAllWithDetailsAsync();
        Task<Screening?> GetByIdAsync(int id);
        Task<Screening?> GetByIdWithDetailsAsync(int id);
        Task<List<Screening>> GetByDayAsync(int dayIndex, int? cinemaId);
        /// <summary>Returns null on success, error message on conflict.</summary>
        Task<string?> CreateAsync(Screening screening);
        /// <summary>Returns null on success, error message on conflict.</summary>
        Task<string?> UpdateAsync(Screening screening);
        Task DeleteAsync(int id);
    }
}
