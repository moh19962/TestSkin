using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class UserContext : IUserContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User GetUser(int userId)
        {

            User userDetails = new User();

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@UserID", userId));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userDetails.UserID = Convert.ToInt32(reader["UserID"]);
                    userDetails.Name = reader["Name"].ToString();
                    userDetails.Lastname = reader["LastName"].ToString();
                    userDetails.Email = reader["Email"].ToString();
                    userDetails.Password = reader["Password"].ToString();
                    userDetails.RoleId = Convert.ToInt32(reader["Role"]);
                }

                return userDetails;
            }


        }

        public void UpdateUser(User account, int UserID)
        {
            string query = $"UPDATE Users SET Name = @Name, LastName = @LastName, Email = @Email, Password = @Password WHERE UserID = @UserID";


            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                    cmd.Parameters.Add(new SqlParameter("@Name", account.Name));
                    cmd.Parameters.Add(new SqlParameter("@LastName", account.Lastname));
                    cmd.Parameters.Add(new SqlParameter("@Email", account.Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", account.Password));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<User> GetAdmins()
        {
            List<User> adminList = new List<User>();

            string query = "SELECT * FROM Users WHERE Role = 2";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.Name = reader["Name"].ToString();
                    user.Lastname = reader["LastName"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.RoleId = Convert.ToInt32(reader["Role"]);
                    adminList.Add(user);
                }

                return adminList;
            }
        }

        public void DeleteAdmin(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @userID;";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userID", userId));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
