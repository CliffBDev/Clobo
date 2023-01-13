using System;
using Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateMultipleProducts
{
    public record UpdateMultipleProductsCommand : IRequest<UpdateMultipleProductsResponse>
    {
        public IList<UpdateSingleProductCommand> Products { get; init; }
    }

    public record UpdateMultipleProductsResponse
    {
        public IList<Product> UpdatedProducts { get; init; }
        public IList<Product> NotUpdateProducts { get; init; }
    }

    public class UpdateMultipleProductsCommandHandler : IRequestHandler<UpdateMultipleProductsCommand, UpdateMultipleProductsResponse>
    {
        IApplicationDbContext _context;
        public UpdateMultipleProductsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateMultipleProductsResponse> Handle(UpdateMultipleProductsCommand request, CancellationToken cancellationToken)
        {
            List<Product> productsNotFound = new();
            var idList = request.Products.Select(x => x.Id);

            var products = await _context.Products.Where(x => idList.Contains(x.Id)).ToListAsync();

            foreach (var product in products)
            {
                var productRequest = request.Products.FirstOrDefault(x => x.Id == product.Id);

                if (productRequest is not null)
                {
                    product.Name = productRequest.Name;
                    product.Description = productRequest.Description;
                    product.SerialNumber = productRequest.SerialNumber;
                    product.Price = productRequest.Price;
                }
                else
                {
                    productsNotFound.Add(product);
                }
            }

            _context.Products.UpdateRange(products);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateMultipleProductsResponse()
            {
                UpdatedProducts = products,
                NotUpdateProducts = productsNotFound
            };

        }
    }
}

