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
                    userdetails.Adress = reader["Adres"].ToString();
                    userdetails.Password = reader["Password"].ToString();
                    userdetails.RoleId = Convert.ToInt32(reader["Role"]);
                }

                return userdetails;
            }


        }
    }
}
