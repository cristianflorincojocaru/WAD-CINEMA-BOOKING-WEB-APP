using cinemawebapp.Models;

namespace cinemawebapp.Repositories.Interfaces
{
    public interface IScreeningRepository
    {
        Task<List<Screening>> GetAllWithDetailsAsync();
        Task<Screening?> GetByIdAsync(int id);
        Task<Screening?> GetByIdWithDetailsAsync(int id);
        Task<List<Screening>> GetByDayAsync(int dayIndex, int? cinemaId);
        Task<bool> HasConflictAsync(int hallId, DateTime start, int durationMinutes, int? excludeId = null);
        Task AddAsync(Screening screening);
        Task UpdateAsync(Screening screening);
        Task DeleteAsync(int id);
    }
}
