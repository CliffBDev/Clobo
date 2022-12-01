using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Common.Interfaces;
using Clobo.Application.Teams.Commands.DeleteTeam;
using Clobo.Application.Teams.Commands.UpdateTeam;
using Clobo.Application.Teams.GetAllTeams.Requests;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Teams.AddTeam.Commands;
using NuGet.Protocol.Core.Types;

namespace Clobo.Controllers
{
    public class TeamController : ApiControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IList<Team>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await Mediator.Send(new GetAllTeamsRequest());
            return Ok(teams);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamCommand command)
        {
            var resp = await Mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamCommand command)
        {
            var resp = await Mediator.Send(command);
            return Ok(resp);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTeam([FromBody] DeleteTeamCommand command)
        {
            var resp = await Mediator.Send(command);
            return Ok(resp);
        }
    }
}
