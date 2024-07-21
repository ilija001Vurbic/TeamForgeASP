using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet("{teamId}")]
        public IActionResult GetTeam(Guid teamId)
        {
            var team = teamService.GetTeamById(teamId);
            if (team == null)
            {
                return NotFound(); // Team not found
            }
            return Ok(team);
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            var teams = teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest("Team is null.");
            }

            teamService.AddTeam(team);
            return CreatedAtAction(nameof(GetTeam), new { teamId = team.Id }, team);
        }

        [HttpPut("{teamId}")]
        public IActionResult UpdateTeam(Guid teamId, [FromBody] Team team)
        {
            if (team == null || teamId != team.Id)
            {
                return BadRequest("Team ID mismatch.");
            }

            var existingTeam = teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return NotFound("Team not found.");
            }

            teamService.UpdateTeam(team);
            return NoContent();
        }

        [HttpDelete("{teamId}")]
        public IActionResult DeleteTeam(Guid teamId)
        {
            var team = teamService.GetTeamById(teamId);
            if (team == null)
            {
                return NotFound("Team not found.");
            }

            teamService.DeleteTeam(teamId);
            return NoContent();
        }
    }
}
