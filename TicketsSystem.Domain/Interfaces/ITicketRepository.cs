using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.Domain.Entities;

namespace TicketsSystem.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> CreateAsync(Ticket entity);
        Task UpdateAsync(Ticket entity);
        Task DeleteAsync(int id);
    }
}
