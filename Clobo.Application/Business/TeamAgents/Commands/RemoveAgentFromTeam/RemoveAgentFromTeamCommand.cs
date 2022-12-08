using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.TeamAgents.Commands.RemoveAgentFromTeam
{
    public record RemoveAgentFromTeamCommand : IRequest<TeamAgent>
    {
        public int AgentId { get; init; }
        public int TeamId { get; init; }
    }

    public class RemoveAgentFromTeamCommandHandler : IRequestHandler<RemoveAgentFromTeamCommand, TeamAgent>
    {
        private readonly IApplicationDbContext _context;
        public RemoveAgentFromTeamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamAgent> Handle(RemoveAgentFromTeamCommand request, CancellationToken cancellationToken)
        {

            //TODO: Don't like this. I had to do this a few times for true validation.
            //Thinking I need to move the context into a repository and then go form there but I don't like validation in a repo layer either
            var teamAgent = await _context.TeamAgents.Include(x => x.Team).Include(x => x.Agent)
                .FirstOrDefaultAsync(x => x.Agent.Id == request.AgentId && x.Team.Id == request.TeamId);

            if (teamAgent is null)
                throw new ArgumentException("Team agent does not exist");

            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.TeamId);

            if (team is null)
                throw new ArgumentException("Team does not exist");

            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.AgentId);

            if (agent is null)
                throw new ArgumentException("Agent does not exist");

            _context.TeamAgents.Remove(teamAgent);

            await _context.SaveChangesAsync(cancellationToken);

            return teamAgent;
        }
    }

}

