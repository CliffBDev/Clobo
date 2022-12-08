using System;
using Clobo.Application.Business.Products.Commands.AddProduct.AddSingleProduct;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;

namespace Clobo.Application.Business.Products.Commands.AddProduct.AddMultipleProducts
{
    public record AddMultipleProductsCommand : IRequest<IList<Product>>
    {
        public IList<AddSingleProductCommand> Products { get; init; }
    }

    public class AddMultipleProductsCommandHandler : IRequestHandler<AddMultipleProductsCommand, IList<Product>>
    {
        private IApplicationDbContext _context;
        public AddMultipleProductsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> Handle(AddMultipleProductsCommand request, CancellationToken cancellationToken)
        {
            List<Product> products = new();

            foreach (var productRequest in request.Products)
            {
                products.Add(new Product()
                {
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    SerialNumber = productRequest.SerialNumber,
                    Price = productRequest.Price
                });
            }

            _context.Products.AddRange(products);

            await _context.SaveChangesAsync(cancellationToken);

            return products;
        }
    }
}

