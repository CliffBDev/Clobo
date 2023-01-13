using System;
using FluentValidation;

namespace Clobo.Application.Business.ProductLines.Commands.AddProuctsToProductLine
{
    public class AddProductsToProductLineCommandValidator : AbstractValidator<AddProductsToProductLineCommand>
    {
        public AddProductsToProductLineCommandValidator()
        {
            RuleFor(x => x.ProductLineId)
                .GreaterThan(0).WithMessage("Proudct Line Id must be greater than 0");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Products cannot be null")
                .NotEmpty().WithMessage("Products cannot be empty");
        }
    }
}

