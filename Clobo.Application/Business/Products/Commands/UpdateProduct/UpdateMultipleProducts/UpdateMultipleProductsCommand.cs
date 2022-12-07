using System;
using Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;

namespace Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateMultipleProducts
{
    public record UpdateMultipleProductsCommand : IRequest<IList<Product>>
    {
        public IList<UpdateSingleProductCommand> Products { get; init; }
    }

    public class UpdateMultipleProductsCommandHandler : IRequestHandler<UpdateMultipleProductsCommand, IList<Product>>
    {
        IApplicationDbContext _context;
        public UpdateMultipleProductsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IList<Product>> Handle(UpdateMultipleProductsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

