using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;

namespace TeamForge.Repository
{
    public class UserRepository : IUserRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public void AddUser(User user)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"INSERT INTO User (Id, Username, Email, PasswordHash, Role)
                             VALUES (@Id, @Username, @Email, @PasswordHash, @Role)";
                conn.Execute(query, new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.PasswordHash,
                    user.Role
                });
            }
        }

        public User GetUserById(Guid userId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "SELECT * FROM User WHERE Id = @UserId";
                return conn.QueryFirstOrDefault<User>(query, new { UserId = userId });
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "SELECT * FROM User WHERE Username = @Username";
                return conn.QueryFirstOrDefault<User>(query, new { Username = username });
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "SELECT * FROM User";
                return conn.Query<User>(query);
            }
        }

        public void UpdateUser(User user)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"UPDATE User
                                 SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash, Role = @Role
                                 WHERE Id = @Id";
                conn.Execute(query, user);
            }
        }

        public void DeleteUser(Guid userId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "DELETE FROM User WHERE Id = @UserId";
                conn.Execute(query, new { UserId = userId });
            }
        }
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword)));
                return hashedPassword == storedHash;
            }
        }
    }
}