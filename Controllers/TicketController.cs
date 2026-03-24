using Microsoft.AspNetCore.Mvc;
using SistemTicket.Domain.Enums;
using TicketsSystem.Domain.Entities;
using TicketsSystem.Domain.Interfaces;
using TicketsSystem.Models.Dtos;

namespace SistemTicket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repository;

        public TicketController(ITicketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                return NotFound();

            var result = new TicketDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status.ToString(),
                Priority = ticket.Priority.ToString()
            };

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTicket()
        {
            var tickets = await _repository.GetAllAsync();

            var ticketsDto = tickets.Select(t => new TicketDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString()
            }).ToList();

            return Ok(ticketsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Title is mandatory");

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("description is mandatory");

            if (request.Priority == null)
                return BadRequest("Priority cant be null");

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority.Value,
                Status = TicketStatus.Open
            };

            var created = await _repository.CreateAsync(ticket);

            return Ok(new { id = created.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTicketDto request)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.Priority = request.Priority;
            existing.Status = request.Status;

            await _repository.UpdateAsync(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}