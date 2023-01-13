using System;
using FluentValidation;

namespace Clobo.Application.Business.ProductLines.Commands.RemoveProductsFromProductLine
{
    public class RemoveProductFromProductLineCommandValidator : AbstractValidator<RemoveProductFromProductLineCommand>
    {
        public RemoveProductFromProductLineCommandValidator()
        {
            RuleFor(x => x.ProductLineId)
                .GreaterThan(0).WithMessage("Product Line Id must be greater than 0");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Products cannot be null")
                .NotEmpty().WithMessage("Products cannot be empty");

        }
    }
}

