using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TeamForge.Service.Common;
using TeamForge.Model;
using TeamForge.Service;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamGeneratorController : ControllerBase
    {
        private readonly ITeamGeneratorService teamGeneratorService;
        private readonly IPlayerService playerService;

        public TeamGeneratorController(ITeamGeneratorService teamGeneratorService, IPlayerService playerService)
        {
            this.teamGeneratorService = teamGeneratorService;
            this.playerService = playerService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateTeams([FromBody] GenerateTeamsRequest request)
        {
            if (request.NumberOfTeams <= 0)
            {
                return BadRequest("Number of teams must be greater than zero.");
            }

            var players = playerService.GetAllPlayers();
            if (players == null || players.Count() == 0)
            {
                return BadRequest("No players available.");
            }

            var teams = teamGeneratorService.GenerateTeams(players.ToList(), request.NumberOfTeams);

            return Ok(teams);
        }
    }

    public class GenerateTeamsRequest
    {
        public int NumberOfTeams { get; set; }
    }
}