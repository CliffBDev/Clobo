using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Teams.Commands.DeleteTeam
{
    public record DeleteTeamCommand : IRequest<int>
    {
        public int Id
        {
            get; init;
        }
    }

    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, int>
    {
        IApplicationDbContext _context;
        public DeleteTeamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (team is null)
                throw new ArgumentException("Team does not exist");

            _context.Teams.Remove(team);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

