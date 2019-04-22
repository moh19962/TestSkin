using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class ProductContext : IProductContext
    {
        private string ConnectionString { get; set; } = "Data Source=gulpower.database.windows.net;Initial Catalog=SkinShop;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddProduct(Product product)
        {
            string query = $"INSERT INTO [Product](ProductName, ProductPrice, Image) VALUES(@ProductName,@Price, @Image)";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.Productname));
                    cmd.Parameters.Add(new SqlParameter("@Price", product.Productprice));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Images));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
