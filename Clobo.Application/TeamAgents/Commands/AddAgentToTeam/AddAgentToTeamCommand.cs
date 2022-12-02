using System;
using MediatR;
using Clobo.Domain.Entities;
using Clobo.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.TeamAgents.Commands.AddAgentToTeam
{
    public record AddAgentToTeamCommand : IRequest<TeamAgent>
    {
        public int AgentId { get; init; }
        public int TeamId { get; init; }
    }

    public class AddAgentToTeamCommandHandler : IRequestHandler<AddAgentToTeamCommand, TeamAgent>
    {
        private readonly IApplicationDbContext _context;

        public AddAgentToTeamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamAgent> Handle(AddAgentToTeamCommand request, CancellationToken cancellationToken)
        {
            var teamAgentExists = await _context.TeamAgents.Include(x => x.Team).Include(x => x.Agent).FirstOrDefaultAsync(x => x.Agent.Id == request.AgentId && x.Team.Id == request.TeamId);

            if (teamAgentExists == null)
                throw new ArgumentException("Agent already belongs to this team");

            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.TeamId);

            if (team == null)
                throw new ArgumentException("Team does not exist");

            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.AgentId);

            if (agent == null)
                throw new ArgumentException("Agent does not exist");

            var teamAgentToAdd = new TeamAgent()
            {
                Team = team,
                Agent = agent
            };

            _context.TeamAgents.Add(teamAgentToAdd);

            await _context.SaveChangesAsync(cancellationToken);

            return teamAgentToAdd;

        }
    }
}

