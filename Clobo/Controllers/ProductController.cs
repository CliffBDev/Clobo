using Clobo.Application.Business.Products.Commands.AddProduct.AddMultipleProducts;
using Clobo.Application.Business.Products.Commands.AddProduct.AddSingleProduct;
using Clobo.Application.Business.Products.Commands.DeleteProduct;
using Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateMultipleProducts;
using Clobo.Application.Business.Products.Commands.UpdateProduct.UpdateSingleProduct;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clobo.Controllers
{
    public class ProductController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSingleProduct([FromBody] AddSingleProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPost("multiple")]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddMultipleProducts([FromBody] AddMultipleProductsCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSingleProduct([FromBody] UpdateSingleProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("multiple")]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMultipleProducts([FromBody] UpdateMultipleProductsCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}

