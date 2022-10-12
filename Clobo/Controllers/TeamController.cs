using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clobo.Application.Requests.Teams;
using Clobo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
