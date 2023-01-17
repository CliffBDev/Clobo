using System;
using FluentValidation;

namespace Clobo.Application.Business.Tickets.Commands.AddTicket
{
    public class AddTicketCommandValidator : AbstractValidator<AddTicketCommand>
    {
        public AddTicketCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId cannot empty")
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0");

            RuleFor(x => x.ProductId)
                 .NotEmpty().WithMessage("Product cannot empty")
                 .GreaterThan(0).WithMessage("ProductId must be greater than 0");
        }
    }
}

