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
    public class MatchRepository : IMatchRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public void AddMatch(Match match)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"INSERT INTO Match (Id, DateTime, Location, Team1Id, Team2Id)
                                 VALUES (@Id, @DateTime, @Location, @Team1Id, @Team2Id)";
                conn.Execute(query, match);
            }
        }

        public Match GetMatchById(Guid matchId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT * FROM Match WHERE Id = @MatchId";
                return conn.QueryFirstOrDefault<Match>(query, new { MatchId = matchId });
            }
        }

        public IEnumerable<Match> GetAllMatches()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT * FROM Match";
                return conn.Query<Match>(query);
            }
        }

        public void UpdateMatch(Match match)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"UPDATE Match 
                                 SET DateTime = @DateTime, Location = @Location, Team1Id = @Team1Id, Team2Id = @Team2Id
                                 WHERE Id = @Id";
                conn.Execute(query, match);
            }
        }

        public void DeleteMatch(Guid matchId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "DELETE FROM Match WHERE Id = @MatchId";
                conn.Execute(query, new { MatchId = matchId });
            }
        }
    }
}
