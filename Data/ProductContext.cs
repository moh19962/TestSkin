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
        private string ConnectionString { get; set; } = "Data Source=gulpower.database.windows.net;Initial Catalog=SkinShop;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddProduct(Product product)
        {
            string query = $"INSERT INTO [Product](ProductName, ProductPrice, Image, Description) VALUES(@ProductName,@Price, @Image, @Description)";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.Productname));
                    cmd.Parameters.Add(new SqlParameter("@Price", product.Productprice));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Images));
                    cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
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


        public Product GetProductByID(int ProductID)
        {

            Product product = new Product();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {

                SqlCommand command = new SqlCommand("GetProductByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Productname = reader["ProductName"].ToString();
                    product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                    product.Images = reader["Image"].ToString();
                    product.Description = reader["Description"].ToString();
                }

                return product;
            }
        }


        public void EditProduct(int productID, Product product)
        {
            string query = $"UPDATE Product SET ProductName = @ProductName, ProductPrice = @ProductPrice, Image = @Image  WHERE ProductID = @ProductID";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProductID", productID));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.Productname));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Productprice));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Images));
                    cmd.Parameters.Add(new SqlParameter("@Image", product.Description));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public List<Product> GetCurrentProduct(int productID)
        //{

        //    List<Product> productdetails = new List<Product>();

        //    string query = "SELECT * FROM Product WHERE ProductID = @ProductID";



        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.Add(new SqlParameter("@ProductID", productID));
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Product product = new Product();
        //            product.ProductID = Convert.ToInt32(reader["ProductID"]);
        //            product.Productname = reader["ProductName"].ToString();
        //            product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
        //            product.Images = reader["Image"].ToString();
        //            productdetails.Add(product);
        //        }

        //        return productdetails;
        //    }

        //}
    }

}
