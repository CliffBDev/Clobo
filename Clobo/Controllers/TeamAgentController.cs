using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Business.TeamAgents.Commands.AddAgentToTeam;
using Clobo.Application.Business.TeamAgents.Commands.AgentTeamLead;
using Clobo.Application.Business.TeamAgents.Commands.RemoveAgentFromTeam;
using Clobo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clobo.Controllers
{
    public class TeamAgentController : ApiControllerBase
    {
        [HttpPut("/addAgentToTeam")]
        [ProducesResponseType(typeof(TeamAgent), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAgentToTeam([FromBody] AddAgentToTeamCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("/agentTeamLead")]
        [ProducesResponseType(typeof(TeamAgent), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] AgentTeamLeadCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("/removeAgentFromTeam")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] RemoveAgentFromTeamCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}

