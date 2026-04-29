using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _repo;
        public CinemaService(ICinemaRepository repo) { _repo = repo; }

        public Task<List<Cinema>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Cinema?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Cinema cinema) => _repo.AddAsync(cinema);
        public Task UpdateAsync(Cinema cinema) => _repo.UpdateAsync(cinema);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
