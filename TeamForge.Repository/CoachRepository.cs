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
    public class CoachRepository : ICoachRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public void AddCoach(Coach coach)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert into User table
                        string userQuery = @"INSERT INTO User (Id, Username, Email, PasswordHash, Role)
                                             VALUES (@Id, @Username, @Email, @PasswordHash, @Role)";
                        conn.Execute(userQuery, new
                        {
                            coach.User.Id,
                            coach.User.Username,
                            coach.User.Email,
                            coach.User.PasswordHash,
                            Role = "Coach"
                        }, transaction);

                        // Insert into Coach table
                        string coachQuery = @"INSERT INTO Coach (Id, UserId, Specialization, ExperienceYears, ContactInfo)
                                              VALUES (@Id, @UserId, @Specialization, @ExperienceYears, @ContactInfo)";
                        conn.Execute(coachQuery, new
                        {
                            coach.Id,
                            UserId = coach.User.Id,
                            coach.Specialization,
                            coach.ExperienceYears,
                            coach.ContactInfo
                        }, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Coach GetCoachById(Guid coachId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT c.*, u.* 
                                 FROM Coach c 
                                 JOIN User u ON c.UserId = u.Id
                                 WHERE c.Id = @CoachId";
                return conn.Query<Coach, User, Coach>(query, (coach, user) => { coach.User = user; return coach; }, new { CoachId = coachId }).FirstOrDefault();
            }
        }

        public IEnumerable<Coach> GetAllCoaches()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT c.*, u.* 
                                 FROM Coach c 
                                 JOIN User u ON c.UserId = u.Id";
                return conn.Query<Coach, User, Coach>(query, (coach, user) => { coach.User = user; return coach; });
            }
        }

        public void UpdateCoach(Coach coach)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"UPDATE Coach 
                                 SET UserId = @UserId, Specialization = @Specialization, ExperienceYears = @ExperienceYears, ContactInfo = @ContactInfo
                                 WHERE Id = @Id";
                conn.Execute(query, coach);
            }
        }

        public void DeleteCoach(Guid coachId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "DELETE FROM Coach WHERE Id = @CoachId";
                conn.Execute(query, new { CoachId = coachId });
            }
        }
    }
}
