using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand : IRequest<bool>
    {
        public int CustomerId { get; init; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x => x.CustomerUsers).FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer is null)
                throw new ArgumentNullException("Customer could not be found");

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

