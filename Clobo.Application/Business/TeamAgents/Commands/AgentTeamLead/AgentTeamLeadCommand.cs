using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.TeamAgents.Commands.AgentTeamLead
{
    public record AgentTeamLeadCommand : IRequest<TeamAgent>
    {
        public int TeamId { get; init; }
        public int AgentId { get; init; }
    }

    public class AgentTeamLeadCommandHandler : IRequestHandler<AgentTeamLeadCommand, TeamAgent>
    {
        private readonly IApplicationDbContext _context;

        public AgentTeamLeadCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamAgent> Handle(AgentTeamLeadCommand request, CancellationToken cancellationToken)
        {
            var teamAgent = await _context.TeamAgents.Include(x => x.Agent).Include(x => x.Team)
                .FirstOrDefaultAsync(x => x.Team.Id == request.TeamId && x.Agent.Id == request.AgentId);

            if (teamAgent == null)
                throw new ArgumentException("Team agent does not exist");

            teamAgent.IsLead = !teamAgent.IsLead;

            _context.TeamAgents.Update(teamAgent);

            await _context.SaveChangesAsync(cancellationToken);

            return teamAgent;
        }
    }
}

