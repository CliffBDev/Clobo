using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Agents.Requests.GetAllAgents
{
    public record GetAllAgentsRequest : IRequest<IList<Agent>>;

    public class GetAllAgentsRequestHandler : IRequestHandler<GetAllAgentsRequest, IList<Agent>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAgentsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Agent>> Handle(GetAllAgentsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Agents.ToListAsync();
        }
    }
}

