using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Products.Requests.GetAllProducts
{
    public record GetAllProductsRequest : IRequest<IList<Product>>;

    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IList<Product>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Product>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync();
        }
    }
}

