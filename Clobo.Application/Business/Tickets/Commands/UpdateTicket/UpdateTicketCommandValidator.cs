using System;
using FluentValidation;

namespace Clobo.Application.Business.Tickets.Commands.UpdateTicket
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product Id must be greater than 0");

            RuleFor(x => x.TicketStatus)
                .NotEmpty().WithMessage("Ticket Status cannot be empty");
        }
    }
}

