using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Teams.Commands.UpdateTeam
{
    public record UpdateTeamCommand : IRequest<Team>
    {
        public int Id { get; set; }
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

            if (dbTeam == null)
                throw new ArgumentException($"Team with an Id of {request.Id} could not be found");

            dbTeam.Name = request.Name;

            _context.Teams.Update(dbTeam);

            await _context.SaveChangesAsync(cancellationToken);

            return dbTeam;
        }
    }
}

