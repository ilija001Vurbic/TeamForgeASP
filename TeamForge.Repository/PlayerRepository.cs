using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;

namespace TeamForge.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public void AddPlayer(Player player)
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
                            player.User.Id,
                            player.User.Username,
                            player.User.Email,
                            player.User.PasswordHash,
                            Role = "Player"
                        }, transaction);

                        // Insert into Player table
                        string playerQuery = @"INSERT INTO Player (Id, UserId, Height, Weight, Age, Blocking, Attacking, Serving, Passing, Setting)
                                               VALUES (@Id, @UserId, @Height, @Weight, @Age, @Blocking, @Attacking, @Serving, @Passing, @Setting)";
                        conn.Execute(playerQuery, new
                        {
                            player.Id,
                            UserId = player.User.Id,
                            player.Height,
                            player.Weight,
                            player.Age,
                            player.Blocking,
                            player.Attacking,
                            player.Serving,
                            player.Passing,
                            player.Setting
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


        public Player GetPlayerById(Guid playerId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT p.*, u.*
                                 FROM Player p
                                 JOIN User u ON p.UserId = u.Id
                                 WHERE p.Id = @PlayerId";
                return conn.Query<Player, User, Player>(query, (player, user) => { player.User = user; return player; }, new { PlayerId = playerId }).FirstOrDefault();
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT p.*, u.*
                                 FROM Player p
                                 JOIN User u ON p.UserId = u.Id";
                return conn.Query<Player, User, Player>(query, (player, user) => { player.User = user; return player; });
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update User table
                        string userQuery = @"UPDATE User
                                             SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash, Role = 'Player'
                                             WHERE Id = @Id";
                        conn.Execute(userQuery, player.User, transaction);

                        // Update Player table
                        string playerQuery = @"UPDATE Player
                                               SET Height = @Height, Weight = @Weight, Age = @Age, Blocking = @Blocking, Attacking = @Attacking, Serving = @Serving, Passing = @Passing, Setting = @Setting
                                               WHERE Id = @Id";
                        conn.Execute(playerQuery, player, transaction);

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

        public void DeletePlayer(Guid playerId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get UserId from Player table
                        string getUserIdQuery = "SELECT UserId FROM Player WHERE Id = @PlayerId";
                        var userId = conn.QueryFirstOrDefault<Guid>(getUserIdQuery, new { PlayerId = playerId });

                        // Delete from Player table
                        string playerQuery = "DELETE FROM Player WHERE Id = @PlayerId";
                        conn.Execute(playerQuery, new { PlayerId = playerId }, transaction);

                        // Delete from User table
                        string userQuery = "DELETE FROM User WHERE Id = @UserId";
                        conn.Execute(userQuery, new { UserId = userId }, transaction);

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
    }
}
