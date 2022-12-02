using System;
using FluentValidation;

namespace Clobo.Application.TeamAgents.Commands.RemoveAgentFromTeam
{
    public class RemoveAgentFromTeamCommandValidator : AbstractValidator<RemoveAgentFromTeamCommand>
    {
        public RemoveAgentFromTeamCommandValidator()
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

