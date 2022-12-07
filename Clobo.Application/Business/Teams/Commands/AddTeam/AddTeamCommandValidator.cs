using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace Clobo.Application.Business.Teams.Commands.AddTeam;

public class AddTeamCommandHandlerValidtor : AbstractValidator<AddTeamCommand>
{
    public AddTeamCommandHandlerValidtor()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(4).WithMessage("Name must be 4 characters long.")
            .MaximumLength(25).WithMessage("Name cannot be more than 25 characters");
    }
}