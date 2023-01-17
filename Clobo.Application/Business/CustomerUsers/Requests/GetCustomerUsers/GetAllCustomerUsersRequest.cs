using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.CustomerUsers.Requests.GetCustomerUsers
{
    public record GetAllCustomerUsersRequest : IRequest<IList<CustomerUser>>
    {
        public int CustomerId { get; init; }
    }

    public class GetAllCustomerUsersRequestHandler : IRequestHandler<GetAllCustomerUsersRequest, IList<CustomerUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCustomerUsersRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CustomerUser>> Handle(GetAllCustomerUsersRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x => x.CustomerUsers).FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer is null)
                throw new ArgumentException("Customer could not be found");

            return customer.CustomerUsers;
        }
    }
}

