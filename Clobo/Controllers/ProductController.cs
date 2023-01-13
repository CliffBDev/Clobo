using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Business.Products.Commands.AddProduct.AddMultipleProducts;
using Clobo.Application.Business.Products.Commands.AddProduct.AddSingleProduct;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

    }
}

