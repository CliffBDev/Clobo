using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Customers.Requests.GetAllCustomers
{
    public record GetAllCustomersRequest : IRequest<IList<Customer>>;

    public class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, IList<Customer>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCustomersRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            return await _context.Customers.Include(x => x.CustomerUsers).ToListAsync();
        }
    }
}

