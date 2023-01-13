using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Teams.Commands.UpdateTeam
{
    public record UpdateTeamCommand : IRequest<Team>
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Team>
    {
        IApplicationDbContext _context;
        public UpdateTeamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var dbTeam = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (dbTeam is null)
                throw new ArgumentException("Team does not exist");

            dbTeam.Name = request.Name;

            _context.Teams.Update(dbTeam);

            await _context.SaveChangesAsync(cancellationToken);

            return dbTeam;
        }
    }
}

