using System;
using Clobo.Application.Business.Products.Commands.AddProduct.AddSingleProduct;
using FluentValidation;

namespace Clobo.Application.Business.Products.Commands.AddProduct.AddMultipleProducts
{
    public class AddMultipleProductsCommandValidator : AbstractValidator<AddMultipleProductsCommand>
    {
        public AddMultipleProductsCommandValidator()
        {
            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("Products cannot be empty");

            //This works and is the most reusable way to do things, but I don't like the messages it produces.
            RuleForEach(x => x.Products)
                .SetValidator(new AddSingleProductCommandValidator());
        }
    }
}

