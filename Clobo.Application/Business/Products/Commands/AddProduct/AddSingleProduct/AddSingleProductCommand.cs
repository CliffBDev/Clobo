using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;

namespace Clobo.Application.Business.Products.Commands.AddProduct.AddSingleProduct
{
    public record AddSingleProductCommand : IRequest<Product>
    {
        public string Name { get; init; }
        public string? SerialNumber { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
    }

    public class AddSingleProductCommandHandler : IRequestHandler<AddSingleProductCommand, Product>
    {
        IApplicationDbContext _context;

        public AddSingleProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(AddSingleProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                SerialNumber = request.SerialNumber,
                Description = request.Description,
                Price = request.Price
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}

