using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.CustomerUsers.Commands.UpdateCustomerUser
{
    public record UpdateCustomerUserCommand : IRequest<CustomerUser>
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Title { get; init; }
        public bool IsPrimary { get; init; }
    }

    public class UpdateCustomerUserCommandHandler : IRequestHandler<UpdateCustomerUserCommand, CustomerUser>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCustomerUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerUser> Handle(UpdateCustomerUserCommand request, CancellationToken cancellationToken)
        {
            var customerUser = await _context.CustomerUsers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (customerUser is null)
                throw new ArgumentNullException("Customer user could not be found");

            customerUser.FirstName = customerUser.FirstName;
            customerUser.LastName = customerUser.LastName;
            customerUser.Email = customerUser.Email;
            customerUser.Title = customerUser.Title;
            customerUser.IsPrimary = customerUser.IsPrimary;

            _context.CustomerUsers.Update(customerUser);

            await _context.SaveChangesAsync(cancellationToken);

            return customerUser;
        }
    }
}

