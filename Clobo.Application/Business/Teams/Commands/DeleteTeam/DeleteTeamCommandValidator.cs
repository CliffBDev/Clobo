using System;
using Clobo.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

