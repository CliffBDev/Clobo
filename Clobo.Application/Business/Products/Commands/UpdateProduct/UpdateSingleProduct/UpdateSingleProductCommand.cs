using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;

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

        public Task<Product> Handle(UpdateSingleProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

