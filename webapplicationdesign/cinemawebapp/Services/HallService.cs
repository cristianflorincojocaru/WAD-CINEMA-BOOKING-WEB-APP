using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _repo;
        public HallService(IHallRepository repo) { _repo = repo; }

        public Task<List<Hall>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<Hall>> GetAllWithCinemaAsync() => _repo.GetAllWithCinemaAsync();
        public Task<Hall?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Hall?> GetByIdWithCinemaAsync(int id) => _repo.GetByIdWithCinemaAsync(id);
        public Task AddAsync(Hall hall) => _repo.AddAsync(hall);
        public Task UpdateAsync(Hall hall) => _repo.UpdateAsync(hall);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
