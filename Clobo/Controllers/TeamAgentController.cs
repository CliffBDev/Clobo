using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.TeamAgents.Commands.AddAgentToTeam;
using Clobo.Application.TeamAgents.Commands.AgentTeamLead;
using Clobo.Application.TeamAgents.Commands.RemoveAgentFromTeam;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clobo.Controllers
{
    public class TeamAgentController : ApiControllerBase
    {
        [HttpPut("/addAgentToTeam")]
        public async Task<IActionResult> AddAgentToTeam([FromBody] AddAgentToTeamCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("/agentTeamLead")]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] AgentTeamLeadCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("/removeAgentFromTeam")]
        public async Task<IActionResult> MakeAgentTeamLead([FromBody] RemoveAgentFromTeamCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}

