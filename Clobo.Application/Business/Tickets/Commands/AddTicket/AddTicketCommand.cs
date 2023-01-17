using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Tickets.Commands.AddTicket
{
    public record AddTicketCommand : IRequest<Ticket>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int CustomerId { get; init; }
        public int ProductId { get; init; }
    }

    public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, Ticket>
    {
        private readonly IApplicationDbContext _context;

        public AddTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer is null)
                throw new ArgumentNullException("Customer could not be found");

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);

            if (product is null)
                throw new ArgumentNullException("Product could not be found");

            var ticket = new Ticket()
            {
                Name = request.Name,
                Description = request.Description,
                TicketStatus = TicketStatus.New,
                Customer = customer,
                Product = product
            };

            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync(cancellationToken);

            return ticket;
        }
    }
}

