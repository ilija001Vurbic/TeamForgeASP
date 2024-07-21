using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model
{
    public class TeamGenerator
    {
        public List<List<Player>> GenerateTeams(List<Player> players, int numTeams)
        {
            // Sort players by overall rating (you might adjust this based on specific criteria)
            players.Sort((p1, p2) => p2.OverallRating.CompareTo(p1.OverallRating));

            // Initialize empty teams
            var teams = new List<List<Player>>();
            for (int i = 0; i < numTeams; i++)
            {
                teams.Add(new List<Player>());
            }

            // Distribute players evenly among teams
            int currentTeamIndex = 0;
            foreach (var player in players)
            {
                teams[currentTeamIndex].Add(player);
                currentTeamIndex = (currentTeamIndex + 1) % numTeams;
            }

            return teams;
        }
    }
}
