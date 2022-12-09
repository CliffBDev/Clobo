using System;
using Clobo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product is null)
                throw new ArgumentException("Product does not exist");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

