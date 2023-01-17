using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clobo.Domain.Entities;
using Clobo.Application.Business.CustomerUsers.Requests.GetCustomerUsers;
using Clobo.Application.Business.CustomerUsers.Commands.AddCustomerUser;
using Clobo.Application.Business.CustomerUsers.Commands.UpdateCustomerUser;
using Clobo.Application.Business.CustomerUsers.Commands.DeleteCustomerUser;

namespace Clobo.Controllers
{
    public class CustomerUserController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IList<CustomerUser>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerUsersRequest request)
        {
            var res = await Mediator.Send(request);
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddCustomerUserCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CustomerUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerUserCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerUserCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }
    }
}

