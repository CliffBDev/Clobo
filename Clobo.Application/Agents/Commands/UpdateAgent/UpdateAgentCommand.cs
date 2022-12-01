using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Agents.Commands.UpdateAgent
{
    public record UpdateAgentCommand : IRequest<Agent>
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
    }

    public class UpdateAgentCommandHandler : IRequestHandler<UpdateAgentCommand, Agent>
    {
        IApplicationDbContext _context;
        public UpdateAgentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Agent> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
        {
            var dbAgent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (dbAgent == null)
                throw new ArgumentException($"Agent with Id of {request.Id} could not be found");

            dbAgent.FirstName = request.FirstName;
            dbAgent.LastName = request.LastName;
            dbAgent.Email = request.Email;

            _context.Agents.Update(dbAgent);

            await _context.SaveChangesAsync(cancellationToken);

            return dbAgent;
        }
    }
}

