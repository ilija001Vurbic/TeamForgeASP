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
    public class ScoreRepository : IScoreRepository
    {

        CommonProperties cProperties = new CommonProperties();

        public Score GetScoreById(Guid scoreId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();    
                string query = "SELECT * FROM Score WHERE Id = @ScoreId";
                return conn.QueryFirstOrDefault<Score>(query, new { ScoreId = scoreId });
            }
        }

        public IEnumerable<Score> GetAllScores()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Score";
                return conn.Query<Score>(query);
            }
        }

        public void AddScore(Score score)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = @"INSERT INTO Score (Id, TeamId, SetNumber, Points) 
                             VALUES (@Id, @TeamId, @SetNumber, @Points)";
                conn.Execute(query, score);
            }
        }

        public void UpdateScore(Score score)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {  
                conn.Open();
                string query = @"UPDATE Score 
                             SET TeamId = @TeamId, SetNumber = @SetNumber, Points = @Points
                             WHERE Id = @Id";
                conn.Execute(query, score);
            }
        }

        public void DeleteScore(Guid scoreId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();    
                string query = "DELETE FROM Score WHERE Id = @ScoreId";
                conn.Execute(query, new { ScoreId = scoreId });
            }
        }
    }
}
