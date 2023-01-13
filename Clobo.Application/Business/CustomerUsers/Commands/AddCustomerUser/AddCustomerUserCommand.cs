using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.CustomerUsers.Commands.AddCustomerUser
{
    public record AddCustomerUserCommand : IRequest<CustomerUser>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Title { get; init; }
        public bool IsPrimary { get; init; }
    }

    public class AddCustomerUserCommandHandler : IRequestHandler<AddCustomerUserCommand, CustomerUser>
    {
        private readonly IApplicationDbContext _context;

        public AddCustomerUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerUser> Handle(AddCustomerUserCommand request, CancellationToken cancellationToken)
        {
            var customerUser = await _context.CustomerUsers.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

            if (customerUser is not null)
                throw new ArgumentException("Customer User already exists");

            var newCustomerUser = new CustomerUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Title = request.Title,
                IsPrimary = request.IsPrimary
            };

            _context.CustomerUsers.Add(newCustomerUser);

            await _context.SaveChangesAsync(cancellationToken);

            return newCustomerUser;
        }
    }

}

