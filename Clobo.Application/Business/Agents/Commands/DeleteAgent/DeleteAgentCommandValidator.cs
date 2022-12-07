using System;
using Clobo.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Agents.Commands.DeleteAgent
{
    public class DeleteAgentCommandValidator : AbstractValidator<DeleteAgentCommand>
    {
        public DeleteAgentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than 0");

        }
    }
}

