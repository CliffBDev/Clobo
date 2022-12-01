using System;
using FluentValidation;

namespace Clobo.Application.Agents.Commands.UpdateAgent
{
    public class UpdateAgentCommandValidator : AbstractValidator<UpdateAgentCommand>
    {
        public UpdateAgentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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

