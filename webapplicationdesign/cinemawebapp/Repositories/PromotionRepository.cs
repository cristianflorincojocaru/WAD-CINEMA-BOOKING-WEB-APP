using cinemawebapp.Data;
using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly AppDbContext _context;
        public PromotionRepository(AppDbContext context) { _context = context; }

        public Task<List<Promotion>> GetAllAsync() => _context.Promotions.ToListAsync();
        public async Task<Promotion?> GetByIdAsync(int id) => await _context.Promotions.FindAsync(id);
        public Task<List<Promotion>> GetActiveAsync() => _context.Promotions.Where(p => p.IsActive).ToListAsync();

        public async Task AddAsync(Promotion promotion) { _context.Promotions.Add(promotion); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Promotion promotion) { _context.Promotions.Update(promotion); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo != null) { _context.Promotions.Remove(promo); await _context.SaveChangesAsync(); }
        }
    }
}
