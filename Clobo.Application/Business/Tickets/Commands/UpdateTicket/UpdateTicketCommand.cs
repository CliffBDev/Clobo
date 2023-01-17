using System;
using Clobo.Application.Common.Interfaces;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Tickets.Commands.UpdateTicket
{
    public record UpdateTicketCommand : IRequest<Ticket>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int? AgentId { get; init; }
        public int? TeamId { get; init; }
        public TicketStatus TicketStatus { get; init; }
        public int CustomerId { get; init; }
        public int ProductId { get; init; }
    }

    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Ticket>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.Include(x => x.TicketNotes).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ticket is null)
                throw new ArgumentNullException("Ticket could not be found");

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer is null)
                throw new ArgumentNullException("Customer could not be found");

            ticket.Customer = customer;

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);

            if (product is null)
                throw new ArgumentNullException("Product could not be found");

            ticket.Product = product;

            if (request.AgentId is not null)
            {
                var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == request.AgentId);

                if (agent is null)
                    throw new ArgumentNullException("Agent could not be found");

                ticket.Agent = agent;
            }
            else
                ticket.Agent = null;

            if (request.TeamId is not null)
            {
                var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.TeamId);

                if (team is null)
                    throw new NotImplementedException("Team could not be found");

                ticket.Team = team;
            }
            else
                ticket.Team = null;

            ticket.Name = request.Name;
            ticket.Description = request.Description;
            ticket.TicketStatus = request.TicketStatus;

            _context.Tickets.Update(ticket);

            await _context.SaveChangesAsync(cancellationToken);

            return ticket;
        }
    }
}

