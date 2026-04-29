using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<List<Promotion>> GetActiveAsync();
        Task AddAsync(Promotion promotion);
        Task UpdateAsync(Promotion promotion);
        Task DeleteAsync(int id);
    }
}
