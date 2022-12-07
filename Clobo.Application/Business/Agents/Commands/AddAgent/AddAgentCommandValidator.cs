using System;
using FluentValidation;

namespace Clobo.Application.Business.Agents.Commands.AddAgent
{
    public class AddAgentCommandValidator : AbstractValidator<AddAgentCommand>
    {
        public AddAgentCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name cannot be empty")
                .MinimumLength(1).WithMessage("First Name must be greater than 1 character");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name cannot be empty")
                .MinimumLength(1).WithMessage("Last Name must be greater than 1 character");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Not a valid email address");
        }
    }
}

