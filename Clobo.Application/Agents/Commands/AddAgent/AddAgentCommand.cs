using System;
using MediatR;
using Clobo.Domain.Entities;
using Clobo.Application.Common.Interfaces;

namespace Clobo.Application.Agents.Commands.AddAgent
{
	public record AddAgentCommand : IRequest<Agent>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}

    public class AddAgentCommandHandler : IRequestHandler<AddAgentCommand, Agent>
    {
        IApplicationDbContext _context;

        public AddAgentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Agent> Handle(AddAgentCommand request, CancellationToken cancellationToken)
        {
            var newAgent = new Agent()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _context.Agents.Add(newAgent);

            await _context.SaveChangesAsync(cancellationToken);

            return newAgent;
        }
    }
}

