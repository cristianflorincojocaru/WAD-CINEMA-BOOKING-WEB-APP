using cinemawebapp.Models;

namespace cinemawebapp.Services.Interfaces
{
    public interface ITicketTypeService
    {
        Task<List<TicketType>> GetAllAsync();
        Task<TicketType?> GetByIdAsync(int id);
        Task<TicketType?> GetByNameAsync(string name);
        Task<List<TicketType>> GetActiveAsync();
        Task AddAsync(TicketType ticketType);
        Task UpdateAsync(TicketType ticketType);
        Task DeleteAsync(int id);
    }
}
