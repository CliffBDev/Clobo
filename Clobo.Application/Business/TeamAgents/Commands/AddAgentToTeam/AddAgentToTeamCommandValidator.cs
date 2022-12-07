using System;
using FluentValidation;

namespace Clobo.Application.Business.TeamAgents.Commands.AddAgentToTeam
{
    public class AddAgentToTeamCommandValidator : AbstractValidator<AddAgentToTeamCommand>
    {
        public AddAgentToTeamCommandValidator()
        {
            RuleFor(x => x.AgentId)
                .NotNull().WithMessage("AgentId is required")
                .GreaterThan(0).WithMessage("AgentId must be greater than 0");

            RuleFor(x => x.TeamId)
                .NotNull().WithMessage("TeamId is required")
                .GreaterThan(0).WithMessage("TeamId must be greater than 0");
        }


    }
}

