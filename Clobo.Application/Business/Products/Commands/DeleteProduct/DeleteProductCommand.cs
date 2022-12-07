using System;
using Clobo.Application.Common.Interfaces;
using MediatR;

namespace Clobo.Application.Business.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

