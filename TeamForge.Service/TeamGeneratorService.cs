using System.Collections.Generic;
using System.Linq;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.Service
{
    public class TeamGeneratorService : ITeamGeneratorService
    {
            public List<List<Player>> GenerateTeams(List<Player> players, int numTeams)
            {
                // Calculate overall rating for each player
                foreach (var player in players)
                {
                    player.OverallRating = CalculateOverallRating(player);
                }

                // Sort players by overall rating in descending order
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

            public double CalculateOverallRating(Player player)
            {
                // Example calculation for overall rating
                return (player.Blocking + player.Attacking + player.Serving + player.Passing + player.Setting) / 5.0;
            }
        }
    }