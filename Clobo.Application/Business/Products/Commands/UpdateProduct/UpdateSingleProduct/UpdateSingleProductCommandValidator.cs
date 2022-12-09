using System;
using FluentValidation;

namespace Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct
{
    public class UpdateSingleProductCommandValidator : AbstractValidator<UpdateSingleProductCommand>
    {
        public UpdateSingleProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty")
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MinimumLength(20).WithMessage("Description must be between 20 and 250 characters")
                .MaximumLength(250).WithMessage("Description must be between 20 and 250 characters");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
        }
    }
}

