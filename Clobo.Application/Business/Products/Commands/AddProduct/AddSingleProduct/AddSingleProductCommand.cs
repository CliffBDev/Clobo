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

        public Task<Product> Handle(AddSingleProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

