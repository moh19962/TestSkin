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

        public User GetUser(int UserID)
        {

            User userdetails = new User();

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@UserID", UserID));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userdetails.UserID = Convert.ToInt32(reader["UserID"]);
                    userdetails.Name = reader["Name"].ToString();
                    userdetails.Lastname = reader["LastName"].ToString();
                    userdetails.Email = reader["Email"].ToString();
                    userdetails.Password = reader["Password"].ToString();
                    userdetails.RoleId = Convert.ToInt32(reader["Role"]);
                }

                return userdetails;
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
    }
}
