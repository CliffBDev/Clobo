using System;
using FluentValidation;

namespace Clobo.Application.Business.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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

            RuleFor(x => x.CustomerUsers)
                .NotNull().WithMessage("Users cannot be null")
                .NotEmpty().WithMessage("Users cannot be empty");
        }
    }
}

