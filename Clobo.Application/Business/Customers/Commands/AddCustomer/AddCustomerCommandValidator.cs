using System;
using FluentValidation;

namespace Clobo.Application.Business.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
            //TODO: Do regex checks against below location fields

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer Name cannot be empty");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip Code cannot be empty");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty");
        }
    }
}

