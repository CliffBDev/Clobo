using System;
using FluentValidation;

namespace Clobo.Application.Business.CustomerUsers.Commands.AddCustomerUser
{
    public class AddCustomerUserCommandValidator : AbstractValidator<AddCustomerUserCommand>
    {
        public AddCustomerUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name cannot be empty");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name cannot be empty");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Not a valid email address");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");
        }
    }
}

