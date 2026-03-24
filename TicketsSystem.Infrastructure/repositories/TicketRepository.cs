using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSystem.Domain.Entities;
using TicketsSystem.Domain.Interfaces;
using TicketsSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace TicketsSystem.Infrastructure.Repositories
{

    public class TicketRepository : TicketsSystem.Domain.Interfaces.ITicketRepository
    {
        private readonly TicketsSystemDBContext _context;

        public TicketRepository(TicketsSystemDBContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<Ticket> CreateAsync(Ticket entity)
        {
            _context.Tickets.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Ticket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Tickets.FindAsync(id);
            if (entity != null)
            {
                _context.Tickets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}