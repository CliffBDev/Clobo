using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.TicketNotes.Requests.GetTicketNotes
{
    public record GetTicketNotesRequest : IRequest<IList<TicketNote>>
    {
        public int TicketId { get; init; }
    }

    public class GetTicketNotesRequestHandler : IRequestHandler<GetTicketNotesRequest, IList<TicketNote>>
    {
        private readonly IApplicationDbContext _context;

        public GetTicketNotesRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TicketNote>> Handle(GetTicketNotesRequest request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.Include(x => x.TicketNotes).ThenInclude(x => x.Agent).FirstOrDefaultAsync(x => x.Id == request.TicketId);

            if (ticket is null)
                throw new ArgumentNullException("Ticket could not be found");

            return ticket.TicketNotes;
        }
    }
}

