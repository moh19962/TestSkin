using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class ProductContext : IProductContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddProduct(Product product)
        {
            string query = $"INSERT INTO [Product](ProductName, ProductPrice, Image, Description, Type) VALUES(@ProductName,@Price, @Image, @Description, @Type)";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.Productname));
                    cmd.Parameters.Add(new SqlParameter("@Price", product.Productprice));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Images));
                    cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@Type", product.Type));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Product> GetProducts()
        {

            List<Product> productDetails = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Productname = reader["ProductName"].ToString();
                    product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                    product.Images = reader["Image"].ToString();
                    product.Type = reader["Type"].ToString();
                    productDetails.Add(product);
                }

                return productDetails;
            }

        }


        public Product GetProductById(int productId)
        {

            Product product = new Product();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand command = new SqlCommand("GetProductByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductID", productId));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Productname = reader["ProductName"].ToString();
                    product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                    product.Images = reader["Image"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.Type = reader["Type"].ToString();
                }

                return product;
            }
        }


        public Product ShowCountByType()
        {

            Product product = new Product();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand command = new SqlCommand("GetCountByType", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Productname = reader["ProductName"].ToString();
                    product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                    product.Images = reader["Image"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.Type = reader["Type"].ToString();
                }
                return product;
            }
        }


        public void EditProduct(Product product)
        {

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.Productname));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Productprice));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Images));
                    cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@Type", product.Type));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Product WHERE ProductID = @ProductID;";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("ProductID", productId));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
