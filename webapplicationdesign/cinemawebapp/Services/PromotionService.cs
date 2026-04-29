using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repo;
        public PromotionService(IPromotionRepository repo) { _repo = repo; }

        public Task<List<Promotion>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Promotion?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<List<Promotion>> GetActiveAsync() => _repo.GetActiveAsync();
        public Task AddAsync(Promotion promotion) => _repo.AddAsync(promotion);
        public Task UpdateAsync(Promotion promotion) => _repo.UpdateAsync(promotion);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
