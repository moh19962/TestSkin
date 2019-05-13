using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class LoginContext : ILoginContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void LoginUser(string Name, string LastName)
        {
            string query = $"INSERT INTO [Users](Name, LastName, Email, Adress, Password, Role) VALUES(@Name, @Lastname, @Email, @Adress, @PassWord, @RoleID)";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", Name));
                    cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User GetUser(string email)
        {

            User userdetails = new User();

            string query = "SELECT * FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@Email", email));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //check if account already exist
                if (reader.HasRows)
                {

                }
                while (reader.Read())
                {
                    userdetails.UserId = Convert.ToInt32(reader["UserID"]);
                    userdetails.Email = reader["Email"].ToString();
                    userdetails.Name = reader["Name"].ToString();
                    userdetails.Password = reader["Password"].ToString();
                    userdetails.RoleId = Convert.ToInt32(reader["Role"]);
                }

                return userdetails;
            }


        }
    }
}
