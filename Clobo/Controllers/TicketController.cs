using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clobo.Domain.Entities;
using Clobo.Application.Business.Tickets.Requests.GetAllTickets;
using Clobo.Application.Business.Tickets.Commands.AddTicket;
using Clobo.Application.Business.Tickets.Commands.UpdateTicket;
using Clobo.Application.Business.Tickets.Commands.DeleteTicket;

namespace Clobo.Controllers
{
    public class TicketController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IList<Ticket>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var res = await Mediator.Send(new GetAllTicketsRequest());
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddTicketCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateTicketCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteTicketCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }
    }
}

