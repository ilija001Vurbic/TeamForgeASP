using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(Guid playerId);
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Guid playerId);
    }
}
