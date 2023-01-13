using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Business.ProductLines.Commands.AddProductLine;
using Clobo.Application.Business.ProductLines.Commands.AddProuctsToProductLine;
using Clobo.Application.Business.ProductLines.Commands.DeleteProductLine;
using Clobo.Application.Business.ProductLines.Commands.RemoveProductsFromProductLine;
using Clobo.Application.Business.ProductLines.Requests.GetAllProductLines;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clobo.Controllers
{
    public class ProductLineController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductLine>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var res = await Mediator.Send(new GetAllProductLinesRequest());
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductLine), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddProductLineCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpPut("addProductsToLine")]
        [ProducesResponseType(typeof(ProductLine), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductsToProductLine([FromBody] AddProductsToProductLineCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpPut("removeProductsFromLine")]
        [ProducesResponseType(typeof(ProductLine), StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProductsFromProductLine([FromBody] RemoveProductsFromProductLineCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteProductLineCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }
    }
}

