using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection.Teams.AddTeam.Commands;

public record AddTeamCommand : IRequest<Team>
{
    public string Name { get; init; }
}

public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, Team>
{
    private readonly IApplicationDbContext _context;
    public AddTeamCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Team> Handle(AddTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team()
        {
            Name = request.Name
        };
        _context.Teams.Add(team);
        await _context.SaveChangesAsync(cancellationToken);
        return team;
    }
}