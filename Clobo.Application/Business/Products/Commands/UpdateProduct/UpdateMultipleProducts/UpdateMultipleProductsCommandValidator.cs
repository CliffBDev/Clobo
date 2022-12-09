using System;
using Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct;
using FluentValidation;

namespace Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateMultipleProducts
{
    public class UpdateMultipleProductsCommandValidator : AbstractValidator<UpdateMultipleProductsCommand>
    {
        public UpdateMultipleProductsCommandValidator()
        {
            RuleFor(x => x.Products)
               .NotEmpty().WithMessage("Products cannot be empty");

            //This works and is the most reusable way to do things, but I don't like the error messages it produces.
            RuleForEach(x => x.Products)
                .SetValidator(new UpdateSingleProductCommandValidator())
                .WithMessage($"Please make sure all products are correct");
        }
    }
}

