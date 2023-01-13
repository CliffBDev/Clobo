using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.ProductLines.Commands.RemoveProductsFromProductLine
{
    public record RemoveProductFromProductLineCommand : IRequest<ProductLine>
    {
        public int ProductLineId { get; init; }
        public IList<Product> Products { get; init; }
    }

    public class RemoveProductFromProductLineCommandHandler : IRequestHandler<RemoveProductFromProductLineCommand, ProductLine>
    {
        private readonly IApplicationDbContext _context;

        public RemoveProductFromProductLineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductLine> Handle(RemoveProductFromProductLineCommand request, CancellationToken cancellationToken)
        {
            var productLine = await _context.ProductLines.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.ProductLineId);

            if (productLine is null)
                throw new ArgumentNullException("Product Line could not be found");

            foreach (var product in request.Products)
            {
                if (productLine.Products.Any(x => x.Id == product.Id))
                {
                    productLine.Products.Remove(product);
                }
            }

            _context.ProductLines.Update(productLine);

            await _context.SaveChangesAsync(cancellationToken);

            return productLine;
        }
    }
}

