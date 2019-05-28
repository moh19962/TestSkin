using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class OrderContext : IOrderContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void PlaceOrder(Order order)
        {
            string query = $"INSERT INTO Orders(UserID, Total) VALUES(@UserID, @Total)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                        cmd.Parameters.Add(new SqlParameter("@UserID", order.User.UserID));
                        cmd.Parameters.Add(new SqlParameter("@Total", order.SubTotal));
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            var orderID = 1;
            PlaceProducts(orderID, order.Cart.Products);
        }

        public void PlaceProducts(int orderID, List<Product> products)
        {
            string query = $"INSERT INTO Order_Product(OrderID, ProductID, Amount) VALUES(@orderID, @ProductID, @Amount)";

            //als hij niet werkt ff conn.open en conn.close buiten de foreach loop zetten.

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var item in products)
                    {
                        cmd.Parameters.Add(new SqlParameter("@orderID", orderID));
                        cmd.Parameters.Add(new SqlParameter("@ProductID", item.ProductID));
                        cmd.Parameters.Add(new SqlParameter("@Amount", item.Amount));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
        }


        public List<Product> GetOrders(int UserId)
        {
            try
            {
                List<Product> GetProductList = new List<Product>();


                string query = "SELECT Orders.OrderID, Orders.UserID, Product.ProductID, Product.ProductName, Orders.Amount, Orders.Total, Product.ProductPrice FROM Orders inner join Product on Orders.ProductID = Product.ProductID WHERE UserID = @UserID";



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", UserId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Product product = new Product();
                        product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        product.Productname = reader["ProductName"].ToString();
                        product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                        product.Amount = Convert.ToInt32(reader["Amount"]);
                        //order.Date = Convert.ToDateTime(reader["Date"]);
                        //order.Total = Convert.ToInt32(reader["Total"]);
                        GetProductList.Add(product);
                    }

                    return GetProductList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
