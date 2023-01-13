using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct
{
    public record UpdateSingleProductCommand : IRequest<Product>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? SerialNumber { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
    }

    public class UpdateSingleProductCommandHandler : IRequestHandler<UpdateSingleProductCommand, Product>
    {
        IApplicationDbContext _context;

        public UpdateSingleProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(UpdateSingleProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product is null)
                throw new ArgumentException("Product does not exist");

            product.Name = request.Name;
            product.SerialNumber = request.SerialNumber;
            product.Description = request.Description;
            product.Price = request.Price;

            _context.Products.Update(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;

        }
    }
}

