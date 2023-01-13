using System;
using FluentValidation;

namespace Clobo.Application.Business.ProductLines.Commands.AddProductLine
{
    public class AddProductLineCommandValidator : AbstractValidator<AddProductLineCommand>
    {
        public AddProductLineCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}

