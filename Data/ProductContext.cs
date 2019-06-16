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

        public void AddToWishList(int productId, int userId, int amount)
        {
            string query = $"INSERT INTO WishList(UserID, ProductID, Amount) VALUES(@userID, @productID, @Amount)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userID", userId));
                    cmd.Parameters.Add(new SqlParameter("@productID", productId));
                    cmd.Parameters.Add(new SqlParameter("@Amount", amount));
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

        public List<Product> GetWishList(int userId)
        {

            try
            {
                List<Product> productWishList = new List<Product>();


                string query = "SELECT WishList.WishListID, WishList.UserID, Product.ProductID, Product.ProductName, Product.Image, WishList.Amount, Product.ProductPrice From WishList inner join Product on WishList.ProductID = Product.ProductID WHERE UserID = @UserID";



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", userId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Product Products = new Product();
                        Products.ProductID = Convert.ToInt32(reader["ProductID"]);
                        Products.Productname = reader["ProductName"].ToString();
                        Products.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                        Products.Images = reader["Image"].ToString();
                        Products.Amount = Convert.ToInt32(reader["Amount"]);
                        productWishList.Add(Products);
                    }

                    return productWishList;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int CheckProductID(int productId, int userId)
        {
            int wishListId = 0;

            string query = "SELECT WishListId FROM WishList WHERE ProductID = @ProductID AND UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ProductID", productId));
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wishListId = Convert.ToInt32(reader["WishListId"]);
                }

                return wishListId;
            }
        }

        public void UpdateAmount(int wishListId, int amount)
        {
            string query = $"UPDATE WishList SET Amount += @Amount WHERE WishListId = @WishListId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@WishListId", wishListId));
                    cmd.Parameters.Add(new SqlParameter("@Amount", amount));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
