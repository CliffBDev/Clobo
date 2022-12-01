using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Agents.Commands.AddAgent;
using Clobo.Application.Agents.Commands.DeleteAgent;
using Clobo.Application.Agents.Commands.UpdateAgent;
using Clobo.Application.Agents.Requests.GetAllAgents;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clobo.Controllers
{
    public class AgentController : ApiControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IList<Agent>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var agents = await Mediator.Send(new GetAllAgentsRequest());
            return Ok(agents);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddAgentCommand command)
        {
            var agent = await Mediator.Send(command);
            return Ok(agent);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateAgentCommand command)
        {
            var agent = await Mediator.Send(command);
            return Ok(agent);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteAgentCommand command)
        {
            var resp = await Mediator.Send(command);
            return Ok(resp);
        }
    }
}

