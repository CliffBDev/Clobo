using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.TeamAgents.Requests.GetAllTeamAgents
{
    public record GetAllTeamAgentsRequest : IRequest<IList<TeamAgent>>;

    public class GetAllTeamAgentsRequestHandler : IRequestHandler<GetAllTeamAgentsRequest, IList<TeamAgent>>
    {
        IApplicationDbContext _context;
        public GetAllTeamAgentsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TeamAgent>> Handle(GetAllTeamAgentsRequest request, CancellationToken cancellationToken)
        {
            return await _context.TeamAgents.Include(x => x.Agent).Include(x => x.Team).ToListAsync();
        }
    }
}

