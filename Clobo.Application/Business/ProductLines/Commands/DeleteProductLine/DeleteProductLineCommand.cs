using System;
using Clobo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.ProductLines.Commands.DeleteProductLine
{
    public record DeleteProductLineCommand : IRequest<bool>
    {
        public int ProductLineId { get; init; }
    }

    public class DeleteProductLineCommandHandler : IRequestHandler<DeleteProductLineCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductLineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductLineCommand request, CancellationToken cancellationToken)
        {
            var productLine = await _context.ProductLines.FirstOrDefaultAsync(x => x.Id == request.ProductLineId);

            if (productLine is null)
                throw new ArgumentNullException("Product Line could not be found");

            _context.ProductLines.Remove(productLine);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

