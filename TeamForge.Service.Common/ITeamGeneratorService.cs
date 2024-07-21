using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface ITeamGeneratorService
    {
        List<List<Player>> GenerateTeams(List<Player> players, int numTeams);
        double CalculateOverallRating(Player player);

    }
}
