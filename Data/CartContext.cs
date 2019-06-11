using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class CartContext : ICartContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<Product> GetProductsFromCart(int userId)
        {
            try
            {
                List<Product> productCartList = new List<Product>();


                string query = "SELECT Cart.CartID, Cart.UserID, Product.ProductID, Product.ProductName, Product.Type, Cart.Amount, Product.ProductPrice FROM Cart inner join Product on Cart.ProductID = Product.ProductID WHERE UserID = @UserID";



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", userId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Product cartProducts = new Product();
                        cartProducts.ProductID = Convert.ToInt32(reader["ProductID"]);
                        cartProducts.Productname = reader["ProductName"].ToString();
                        cartProducts.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                        cartProducts.Amount = Convert.ToInt32(reader["Amount"]);
                        productCartList.Add(cartProducts);
                    }

                    return productCartList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddToCart(int productId, int userId, int amount)
        {
            string query = $"INSERT INTO Cart(UserID, ProductID, Amount) VALUES(@userID, @productID, @Amount)";

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

        public int CheckProductID(int productId, int userId)
        {
            int CartID = 0;

            string query = "SELECT CartID FROM Cart WHERE ProductID = @ProductID AND UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ProductID", productId));
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CartID = Convert.ToInt32(reader["CartID"]);
                }

                return CartID;
            }
        }

        public void UpdateAmount(int cartId, int amount)
        {
            string query = $"UPDATE Cart SET Amount += @Amount WHERE CartID = @CartID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@CartID", cartId));
                    cmd.Parameters.Add(new SqlParameter("@Amount", amount));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProductFromCart(int userId, int productId)
        {
            //string query = "DELETE FROM Cart WHERE ProductID = @ProductID;";
            string query = "DELETE FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID;";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserID", userId));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", productId));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCart(int UserID)
        {
            string query = $"Delete FROM Cart WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userID", UserID));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCart(int UserID, int ProductID, int Amount)
        {
            string query = $"UPDATE Cart SET Amount = @Amount WHERE ProductID = @ProductID AND UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                    cmd.Parameters.Add(new SqlParameter("@Amount", Amount));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
