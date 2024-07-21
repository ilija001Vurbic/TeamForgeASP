using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;
using TeamForge.Repository.Common;
using TeamForge.Service.Common;

namespace TeamForge.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return playerRepository.GetAllPlayers();
        }

        public Player GetPlayerById(Guid playerId)
        {
            return playerRepository.GetPlayerById(playerId);
        }

        public void AddPlayer(Player player)
        {
            playerRepository.AddPlayer(player);
        }

        public void UpdatePlayer(Player player)
        {
            playerRepository.UpdatePlayer(player);
        }

        public void DeletePlayer(Guid playerId)
        {
            playerRepository.DeletePlayer(playerId);
        }
    }
}

