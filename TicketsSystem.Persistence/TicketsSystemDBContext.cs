using Microsoft.EntityFrameworkCore;
using TicketsSystem.Domain.Entities;


namespace TicketsSystem.Persistence
{
    public class TicketsSystemDBContext : DbContext
    {
        public TicketsSystemDBContext(DbContextOptions<TicketsSystemDBContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}

