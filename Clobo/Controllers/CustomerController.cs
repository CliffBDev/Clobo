using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Business.Customers.Commands.AddCustomer;
using Clobo.Application.Business.Customers.Commands.DeleteCustomer;
using Clobo.Application.Business.Customers.Commands.UpdateCustomer;
using Clobo.Application.Business.Customers.Requests.GetAllCustomers;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clobo.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IList<Customer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var res = await Mediator.Send(new GetAllCustomersRequest());
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] UpdateCustomerCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}

