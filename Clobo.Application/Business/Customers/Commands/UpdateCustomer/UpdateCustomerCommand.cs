using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }
        public IList<CustomerUser> CustomerUsers { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x => x.CustomerUsers).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (customer is null)
                throw new ArgumentNullException("Customer could not be found");

            customer.Name = request.Name;
            customer.Address = request.Address;
            customer.City = request.City;
            customer.State = request.State;
            customer.ZipCode = request.ZipCode;
            customer.Country = request.Country;
            customer.CustomerUsers = request.CustomerUsers;

            _context.Customers.Update(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}

