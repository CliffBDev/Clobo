using System;
using Clobo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.CustomerUsers.Commands.DeleteCustomerUser
{
    public record DeleteCustomerUserCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteCustomerUserCommandHandler : IRequestHandler<DeleteCustomerUserCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteCustomerUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteCustomerUserCommand request, CancellationToken cancellationToken)
        {
            var customerUser = await _context.CustomerUsers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (customerUser is null)
                throw new ArgumentNullException("Customer User could not be found");

            _context.CustomerUsers.Remove(customerUser);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

