using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Common.Interfaces;
using Clobo.Application.Teams.Requests;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Teams.Commands;
using NuGet.Protocol.Core.Types;

namespace Clobo.Controllers
{
    public class TeamController : ApiControllerBase
    {
       
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await Mediator.Send(new GetAllTeamsRequest());
            return new OkObjectResult(teams);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamCommand command)
        {
            var resp = await Mediator.Send(command);
            return new OkObjectResult(resp);
        }
    }
}
