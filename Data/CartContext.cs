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
        private string ConnectionString { get; set; } = "Data Source=gulpower.database.windows.net;Initial Catalog=WebshopGagoo;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Cart> GetProductsFromCart(int UserId)
        {
            try
            {
                List<Cart> productCartList = new List<Cart>();


                string query = "SELECT Cart.CartID, Cart.UserID, Product.ProductID, Product.ProductName, Cart.Amount, Product.ProductPrice FROM Cart inner join Product on Cart.ProductID = Product.ProductID WHERE UserID = @UserID";



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", UserId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Cart cartProducts = new Cart();
                        cartProducts.CartID = Convert.ToInt32(reader["CartID"]);
                        cartProducts.UserID = Convert.ToInt32(reader["UserID"]);
                        cartProducts.Product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        cartProducts.Product.Productname = reader["ProductName"].ToString();
                        cartProducts.Product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
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
    }
}
