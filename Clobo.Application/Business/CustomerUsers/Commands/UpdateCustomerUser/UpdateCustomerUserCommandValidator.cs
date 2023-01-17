using System;
using FluentValidation;

namespace Clobo.Application.Business.CustomerUsers.Commands.UpdateCustomerUser
{
    public class UpdateCustomerUserCommandValidator : AbstractValidator<UpdateCustomerUserCommand>
    {
        public UpdateCustomerUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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

