using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.TicketNotes.Commands.AddTicketNote
{
    public record AddTicketNoteCommand : IRequest<TicketNote>
    {
        public int TicketId { get; init; }
        public string Note { get; init; }
        public int AgentId { get; init; }
    }

    public class AddTicketNoteCommandHandler : IRequestHandler<AddTicketNoteCommand, TicketNote>
    {
        private readonly IApplicationDbContext _context;

        public AddTicketNoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketNote> Handle(AddTicketNoteCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.Include(x => x.Agent)
                                               .Include(x => x.Team)
                                               .Include(x => x.Product)
                                               .Include(x => x.Customer)
                                               .Include(x => x.TicketNotes)
                                               .FirstOrDefaultAsync(x => x.Id == request.TicketId);

            if (ticket is null)
                throw new ArgumentNullException("Ticket could not be found");

            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.AgentId);

            if (agent is null)
                throw new ArgumentNullException("Agent could not be found");

            var ticketNote = new TicketNote()
            {
                Note = request.Note,
                Agent = agent
            };

            ticket.TicketNotes.Add(ticketNote);

            _context.Tickets.Update(ticket);

            await _context.SaveChangesAsync(cancellationToken);

            return ticketNote;
        }
    }
}

