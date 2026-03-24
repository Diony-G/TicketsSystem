using SistemTicket.Domain.Enums;

namespace TicketsSystem.Models.Dtos
{
    public class CreateTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriority? Priority { get; set; }
    }
}
