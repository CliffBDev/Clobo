using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Teams.Requests.GetAllTeams;

public record GetAllTeamsRequest : IRequest<IList<Team>>;

public class GetAllTeamsRequestHandler : IRequestHandler<GetAllTeamsRequest, IList<Team>>
{
    private readonly IApplicationDbContext _context;
    public GetAllTeamsRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Team>> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
    {
        return await _context.Teams.Include(x => x.TeamAgents).ThenInclude(x => x.Agent).ToListAsync(cancellationToken);
    }
}