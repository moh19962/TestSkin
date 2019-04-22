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
        public List<Product> GetProducts()
        {

            List<Product> productdetails = new List<Product>();

            string query = "SELECT * FROM Product";



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Productname = reader["ProductName"].ToString();
                    product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                    product.Images = reader["Image"].ToString();
                    productdetails.Add(product);
                }

                return productdetails;
            }

        }
    }

}
