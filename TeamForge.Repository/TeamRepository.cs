using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;

namespace TeamForge.Repository
{
    public class TeamRepository : ITeamRepository
    {
        CommonProperties cProperties = new CommonProperties();
        public void AddTeam(Team team)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"INSERT INTO Team (Id, Name, CoachId)
                                 VALUES (@Id, @Name, @CoachId)";
                conn.Execute(query, team);
            }
        }

        public Team GetTeamById(Guid teamId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT t.*, c.* 
                                 FROM Team t 
                                 LEFT JOIN Coach c ON t.CoachId = c.Id
                                 WHERE t.Id = @TeamId";
                return conn.Query<Team, Coach, Team>(query, (team, coach) => { team.Coach = coach; return team; }, new { TeamId = teamId }).FirstOrDefault();
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT t.*, c.* 
                                 FROM Team t 
                                 LEFT JOIN Coach c ON t.CoachId = c.Id";
                return conn.Query<Team, Coach, Team>(query, (team, coach) => { team.Coach = coach; return team; });
            }
        }

        public void UpdateTeam(Team team)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"UPDATE Team 
                                 SET Name = @Name, CoachId = @CoachId
                                 WHERE Id = @Id";
                conn.Execute(query, team);
            }
        }

        public void DeleteTeam(Guid teamId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "DELETE FROM Team WHERE Id = @TeamId";
                conn.Execute(query, new { TeamId = teamId });
            }
        }
    }
}
