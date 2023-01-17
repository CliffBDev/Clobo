using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Tickets.Requests.GetAllTickets
{
    public record GetAllTicketsRequest : IRequest<IList<Ticket>>;

    public class GetAllTicketsRequestHandler : IRequestHandler<GetAllTicketsRequest, IList<Ticket>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTicketsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Ticket>> Handle(GetAllTicketsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Tickets.Include(x => x.Agent)
                                         .Include(x => x.Team)
                                         .Include(x => x.Product)
                                         .Include(x => x.Customer)
                                         .Include(x => x.TicketNotes)
                                         .ToListAsync();
        }
    }
}

