using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet("{matchId}")]
        public IActionResult GetMatch(Guid matchId)
        {
            var match = matchService.GetMatchById(matchId);
            if (match == null)
            {
                return NotFound(); // Match not found
            }
            return Ok(match);
        }

        [HttpGet]
        public IActionResult GetAllMatches()
        {
            var matches = matchService.GetAllMatches();
            return Ok(matches);
        }

        [HttpPost]
        public IActionResult AddMatch([FromBody] Match match)
        {
            if (match == null)
            {
                return BadRequest("Match is null.");
            }

            matchService.AddMatch(match);
            return CreatedAtAction(nameof(GetMatch), new { matchId = match.Id }, match);
        }

        [HttpPut("{matchId}")]
        public IActionResult UpdateMatch(Guid matchId, [FromBody] Match match)
        {
            if (match == null || matchId != match.Id)
            {
                return BadRequest("Match ID mismatch.");
            }

            var existingMatch = matchService.GetMatchById(matchId);
            if (existingMatch == null)
            {
                return NotFound("Match not found.");
            }

            matchService.UpdateMatch(match);
            return NoContent();
        }

        [HttpDelete("{matchId}")]
        public IActionResult DeleteMatch(Guid matchId)
        {
            var match = matchService.GetMatchById(matchId);
            if (match == null)
            {
                return NotFound("Match not found.");
            }

            matchService.DeleteMatch(matchId);
            return NoContent();
        }
    }

}
