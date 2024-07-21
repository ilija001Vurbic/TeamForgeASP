using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService scoreService;

        public ScoreController(IScoreService scoreService)
        {
            this.scoreService = scoreService;
        }

        [HttpGet("{scoreId}")]
        public IActionResult GetScore(Guid scoreId)
        {
            var score = scoreService.GetScoreById(scoreId);
            if (score == null)
            {
                return NotFound(); // Score not found
            }
            return Ok(score);
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            var scores = scoreService.GetAllScores();
            return Ok(scores);
        }

        [HttpPost]
        public IActionResult AddScore([FromBody] Score score)
        {
            scoreService.AddScore(score);
            return CreatedAtAction(nameof(GetScore), new { scoreId = score.Id }, score);
        }

        [HttpPut("{scoreId}")]
        public IActionResult UpdateScore(Guid scoreId, [FromBody] Score score)
        {
            if (scoreId != score.Id)
            {
                return BadRequest(); // Invalid request
            }

            scoreService.UpdateScore(score);
            return NoContent();
        }

        [HttpDelete("{scoreId}")]
        public IActionResult DeleteScore(Guid scoreId)
        {
            scoreService.DeleteScore(scoreId);
            return NoContent();
        }
    }
}
