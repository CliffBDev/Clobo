using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Business.TeamAgents.Commands.AddAgentToTeam;
using Clobo.Application.Business.TeamAgents.Commands.AgentTeamLead;
using Clobo.Application.Business.TeamAgents.Commands.RemoveAgentFromTeam;
using Clobo.Application.Business.TeamAgents.Requests.GetAllTeamAgents;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clobo.Controllers
{
    [Route("api/teamAgent")]
    [ApiController]
    public class TeamAgentController : ControllerBase
    {
        private ISender _mediator;

        public TeamAgentController(ISender mediator)
        {
            _mediator = mediator;
        }

        //I don't really like the verby names for endpoints but here we are.
        //This is the only thing I could think of to achieve the workflow I am aiming for.

        [HttpGet]
        [ProducesResponseType(typeof(IList<TeamAgent>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetAllTeamAgentsRequest());
            return Ok(res);
        }

        [HttpPut("addAgentToTeam")]
        [ProducesResponseType(typeof(TeamAgent), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAgentToTeam([FromBody] AddAgentToTeamCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("agentTeamLead")]
        [ProducesResponseType(typeof(TeamAgent), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] AgentTeamLeadCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("removeAgentFromTeam")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] RemoveAgentFromTeamCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}

