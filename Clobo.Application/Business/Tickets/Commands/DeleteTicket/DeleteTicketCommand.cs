using System;
using Clobo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Tickets.Commands.DeleteTicket
{
    public record DeleteTicketCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ticket is null)
                throw new ArgumentNullException("Ticket could not be found");

            _context.Tickets.Remove(ticket);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

