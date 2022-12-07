using System;
using Clobo.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Business.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MinimumLength(4).WithMessage("Name must be 4 characters long")
                .MaximumLength(25).WithMessage("Name cannot be more than 25 characters");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than or equal to 0");

        }
    }
}

