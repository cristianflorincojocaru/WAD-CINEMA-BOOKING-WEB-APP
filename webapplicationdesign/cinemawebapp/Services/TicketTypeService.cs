using cinemawebapp.Models;
using cinemawebapp.Repositories.Interfaces;
using cinemawebapp.Services.Interfaces;

namespace cinemawebapp.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _repo;
        public TicketTypeService(ITicketTypeRepository repo) { _repo = repo; }

        public Task<List<TicketType>> GetAllAsync() => _repo.GetAllAsync();
        public Task<TicketType?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<TicketType?> GetByNameAsync(string name) => _repo.GetByNameAsync(name);
        public Task<List<TicketType>> GetActiveAsync() => _repo.GetActiveAsync();
        public Task AddAsync(TicketType ticketType) => _repo.AddAsync(ticketType);
        public Task UpdateAsync(TicketType ticketType) => _repo.UpdateAsync(ticketType);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
