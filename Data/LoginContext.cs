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


        public void LoginUser(string name, string lastName)
        {
            string query = $"INSERT INTO [Users](Name, LastName, Email, Password, Role) VALUES(@Name, @Lastname, @Email, @PassWord, @RoleID)";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", name));
                    cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User GetUser(string email)
        {

            User userDetails = new User();

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
                    userDetails.UserID = Convert.ToInt32(reader["UserID"]);
                    userDetails.Email = reader["Email"].ToString();
                    userDetails.Name = reader["Name"].ToString();
                    userDetails.Password = reader["Password"].ToString();
                    userDetails.RoleId = Convert.ToInt32(reader["Role"]);
                }

                return userDetails;
            }


        }
    }
}
