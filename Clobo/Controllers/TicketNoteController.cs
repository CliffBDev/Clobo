using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clobo.Domain.Entities;
using Clobo.Application.Business.TicketNotes.Requests.GetTicketNotes;
using Clobo.Application.Business.TicketNotes.Commands.AddTicketNote;

namespace Clobo.Controllers
{
    public class TicketNoteController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IList<TicketNote>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetTicketNotesRequest request)
        {
            var res = await Mediator.Send(request);
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketNote), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] AddTicketNoteCommand cmd)
        {
            var res = await Mediator.Send(cmd);
            return Ok(res);
        }
    }
}

