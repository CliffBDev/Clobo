using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.ProductLines.Commands.AddProductLine
{
    public record AddProductLineCommand : IRequest<ProductLine>
    {
        public string Name { get; init; }
    }

    public class AddProductLineCommandHandler : IRequestHandler<AddProductLineCommand, ProductLine>
    {
        IApplicationDbContext _context;
        public AddProductLineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductLine> Handle(AddProductLineCommand request, CancellationToken cancellationToken)
        {
            await CheckIfExists(request.Name);

            var productLine = new ProductLine()
            {
                Name = request.Name
            };

            _context.ProductLines.Add(productLine);

            await _context.SaveChangesAsync(cancellationToken);

            return productLine;
        }

        private async Task CheckIfExists(string name)
        {
            var productLine = await _context.ProductLines.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (productLine is not null)
                throw new ArgumentException("Product Line with the same name already exists");
        }
    }
}

