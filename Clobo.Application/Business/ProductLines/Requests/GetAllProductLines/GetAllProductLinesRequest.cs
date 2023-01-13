using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.ProductLines.Requests.GetAllProductLines
{
    public record GetAllProductLinesRequest : IRequest<IList<ProductLine>>;

    public class GetAllProductLinesRequestHandler : IRequestHandler<GetAllProductLinesRequest, IList<ProductLine>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductLinesRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductLine>> Handle(GetAllProductLinesRequest request, CancellationToken cancellationToken)
        {
            return await _context.ProductLines.Include(x => x.Products).ToListAsync();
        }
    }
}

