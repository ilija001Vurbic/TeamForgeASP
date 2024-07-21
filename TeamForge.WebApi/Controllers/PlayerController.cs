using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetAllPlayers()
        {
            var players = playerService.GetAllPlayers();
            return Ok(players);
        }

        [HttpGet("{playerId}")]
        public ActionResult<Player> GetPlayer(Guid playerId)
        {
            var player = playerService.GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        public ActionResult<Player> AddPlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Player is null.");
            }

            playerService.AddPlayer(player);
            return CreatedAtAction(nameof(GetPlayer), new { playerId = player.Id }, player);
        }

        [HttpPut("{playerId}")]
        public IActionResult UpdatePlayer(Guid playerId, [FromBody] Player player)
        {
            if (player == null || playerId != player.Id)
            {
                return BadRequest("Player ID mismatch.");
            }

            var existingPlayer = playerService.GetPlayerById(playerId);
            if (existingPlayer == null)
            {
                return NotFound("Player not found.");
            }

            playerService.UpdatePlayer(player);
            return NoContent();
        }

        [HttpDelete("{playerId}")]
        public IActionResult DeletePlayer(Guid playerId)
        {
            var player = playerService.GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound("Player not found.");
            }

            playerService.DeletePlayer(playerId);
            return NoContent();
        }
    }
}
