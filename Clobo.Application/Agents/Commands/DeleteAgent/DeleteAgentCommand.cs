using System;
using Clobo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Agents.Commands.DeleteAgent
{
    public record DeleteAgentCommand : IRequest<int>
    {
        public int Id { get; init; }
    }

    public class DeleteAgentCommandHandler : IRequestHandler<DeleteAgentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAgentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (agent == null)
                throw new ArgumentException($"Agent with an Id of {request.Id} could not be found");

            _context.Agents.Remove(agent);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

