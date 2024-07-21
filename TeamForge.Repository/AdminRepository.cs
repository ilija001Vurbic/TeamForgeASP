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
    public class AdminRepository : IAdminRepository
    {
        CommonProperties cProperties = new CommonProperties();
        public void AddAdmin(Admin admin)
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
                            admin.User.Id,
                            admin.User.Username,
                            admin.User.Email,
                            admin.User.PasswordHash,
                            Role = "Admin"
                        }, transaction);

                        // Insert into Admin table
                        string adminQuery = @"INSERT INTO Admin (Id, UserId)
                                              VALUES (@Id, @UserId)";
                        conn.Execute(adminQuery, new
                        {
                            admin.Id,
                            UserId = admin.User.Id
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

            public Admin GetAdminById(Guid adminId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT a.*, u.* 
                                 FROM Admin a 
                                 JOIN User u ON a.UserId = u.Id
                                 WHERE a.Id = @AdminId";
                return conn.Query<Admin, User, Admin>(query, (admin, user) => { admin.User = user; return admin; }, new { AdminId = adminId }).FirstOrDefault();
            }
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"SELECT a.*, u.* 
                                 FROM Admin a 
                                 JOIN User u ON a.UserId = u.Id";
                return conn.Query<Admin, User, Admin>(query, (admin, user) => { admin.User = user; return admin; });
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = @"UPDATE Admin 
                                 SET UserId = @UserId
                                 WHERE Id = @Id";
                conn.Execute(query, admin);
            }
        }

        public void DeleteAdmin(Guid adminId)
        {
            using (var conn = new MySqlConnection(cProperties.connectionString))
            {
                string query = "DELETE FROM Admin WHERE Id = @AdminId";
                conn.Execute(query, new { AdminId = adminId });
            }
        }
    }
}
