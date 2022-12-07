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

        public Task<IList<Product>> Handle(AddMultipleProductsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

