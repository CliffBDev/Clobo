using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Customers.Commands.AddCustomer
{
    public record AddCustomerCommand : IRequest<Customer>
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }
    }

    public record AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly IApplicationDbContext _context;

        public AddCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Name.ToLower());

            if (customer is not null)
                throw new ArgumentNullException("Customer with the same name already exists");

            var customerToAdd = new Customer()
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode,
                Country = request.Country
            };

            _context.Customers.Add(customerToAdd);

            await _context.SaveChangesAsync(cancellationToken);

            return customerToAdd;
        }
    }
}

