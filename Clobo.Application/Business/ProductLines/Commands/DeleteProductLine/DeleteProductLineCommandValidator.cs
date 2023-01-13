using System;
using FluentValidation;

namespace Clobo.Application.Business.ProductLines.Commands.DeleteProductLine
{
    public class DeleteProductLineCommandValidator : AbstractValidator<DeleteProductLineCommand>
    {
        public DeleteProductLineCommandValidator()
        {
            RuleFor(x => x.ProductLineId)
                .GreaterThan(0).WithMessage("Product Line Id must be greater than 0");
        }
    }
}

