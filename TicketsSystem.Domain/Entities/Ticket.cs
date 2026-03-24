using SistemTicket.Domain.Enums;
using System;
namespace TicketsSystem.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority? Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
