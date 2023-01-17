using System;
using FluentValidation;

namespace Clobo.Application.Business.TicketNotes.Commands.AddTicketNote
{
    public class AddTicketNoteCommandValidator : AbstractValidator<AddTicketNoteCommand>
    {
        public AddTicketNoteCommandValidator()
        {
            RuleFor(x => x.TicketId)
                .GreaterThan(0).WithMessage("Ticket Id must be greater than 0");

            RuleFor(x => x.AgentId)
                .GreaterThan(0).WithMessage("Agent Id must be greater than 0");

            RuleFor(x => x.Note)
                .NotEmpty().WithMessage("Note cannot be empty");
        }
    }
}

