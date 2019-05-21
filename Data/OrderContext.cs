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

        //Loop door mijn CartList en doe alle producten inserten.
        public void PlaceOrder(Cart order, int UserId)
        {
            string query = $"INSERT INTO Orders(UserID, ProductID, Amount, Total) VALUES(@UserId, @ProductId, @Amount, @Total)";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //foreach (var item in order)
                    //{
                        cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                        cmd.Parameters.Add(new SqlParameter("@ProductId", order.Product.ProductID));
                        cmd.Parameters.Add(new SqlParameter("@Amount", order.Amount));
                        cmd.Parameters.Add(new SqlParameter("@Total", order.SubTotal));
                        //cmd.Parameters.Add(new SqlParameter("@Date", date));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    //}

                }
            }
        }

        //public void PlaceOrder(Cart order, int UserId)
        //{
        //    string query = $"INSERT INTO Orders(UserID, ProductID, Amount, Total) VALUES(@UserId, @ProductId, @Amount, @Total)";

        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {

        //            cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
        //            cmd.Parameters.Add(new SqlParameter("@ProductId", order.Product.ProductID));
        //            cmd.Parameters.Add(new SqlParameter("@Amount", order.Amount));
        //            cmd.Parameters.Add(new SqlParameter("@Total", order.SubTotal));
        //            //cmd.Parameters.Add(new SqlParameter("@Date", date));
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public List<Order> GetOrders(int UserId)
        {
            try
            {
                List<Order> GetAllList = new List<Order>();


                string query = "SELECT Orders.OrderID, Orders.UserID, Product.ProductID, Product.ProductName, Orders.Amount, Orders.Total, Product.ProductPrice FROM Orders inner join Product on Orders.ProductID = Product.ProductID WHERE UserID = @UserID";



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", UserId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Order order = new Order();
                        order.OrderId = Convert.ToInt32(reader["OrderID"]);
                        order.UserId = Convert.ToInt32(reader["UserID"]);
                        //order.User.Name = reader["Name"].ToString();
                        order.Product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        order.Product.Productname = reader["ProductName"].ToString();
                        order.Product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                        order.Amount = Convert.ToInt32(reader["Amount"]);
                        //order.Date = Convert.ToDateTime(reader["Date"]);
                        order.Total = Convert.ToInt32(reader["Total"]);
                        GetAllList.Add(order);
                    }

                    return GetAllList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
