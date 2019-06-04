using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class OrderContext : IOrderContext
    {
        private string ConnectionString { get; set; } = "Data Source=moooserver.database.windows.net;Initial Catalog=SkinShopz;User ID=MohammadParwani;Password=Hunstongtid6;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Order GetLastOrderID()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                Order order = new Order();

                SqlCommand command = new SqlCommand("GetOrderID", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    order.OrderId = Convert.ToInt32(reader[0]);
                }

                return order;

            }
        }

        public void PlaceOrder(Order order)
        {
            DateTime da = DateTime.Now;
            string date = da.ToString("dd/MM/YYYY");
            string query = $"INSERT INTO Orders(UserID, Date) VALUES(@UserID, @Date)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                        cmd.Parameters.Add(new SqlParameter("@UserID", order.User.UserID));
                        cmd.Parameters.Add(new SqlParameter("@Date", da));
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            var OrderID = GetLastOrderID();
            PlaceProducts(OrderID, order.Cart.Products);

        }

        public void PlaceProducts(Order order, List<Product> products)
        {
            string query = $"INSERT INTO Order_Product(OrderID, ProductID, Amount) VALUES(@orderID, @ProductID, @Amount)";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var item in products)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@orderID", order.OrderId));
                        cmd.Parameters.Add(new SqlParameter("@ProductID", item.ProductID));
                        cmd.Parameters.Add(new SqlParameter("@Amount", item.Amount));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
        }

        
        public Order GetOrder(int UserId)
        {
            Order order = GetLastOrderID();
            try
            {
                order.Cart.Products = new List<Product>();

                string query = "SELECT Orders.OrderID, Orders.UserID, Orders.Date, Order_Product.Amount, Product.ProductID, Product.ProductName, Product.ProductPrice FROM Orders inner join Order_Product on Orders.OrderID = Order_Product.OrderID INNER JOIN Product ON Order_Product.ProductID = Product.ProductID WHERE UserID = @UserID AND Orders.OrderID = @OrderID";


                
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserId));
                    cmd.Parameters.Add(new SqlParameter("@OrderID", order.OrderId));

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        product.Productname = reader["ProductName"].ToString();
                        product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
                        product.Amount = Convert.ToInt32(reader["Amount"]);
                        order.User.UserID = Convert.ToInt32(reader["UserID"]);
                        order.Date = Convert.ToDateTime(reader["Date"]);
                        //order.Total = Convert.ToInt32(reader["Total"]);
                        //order.Date = Convert.ToDateTime(reader["Date"]);
                        //order.Total = Convert.ToInt32(reader["Total"]);
                        order.Cart.Products.Add(product);
                    }

                    return order;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        ////Ik wil in mijn order de naam van de klant geven 
        //public List<Product> GetOrder(int UserId, Order order)
        //{
        //    var Order = GetLastOrderID();
        //    try
        //    {
        //        List<Product> GetProductList = new List<Product>();

        //        string query = "SELECT Orders.OrderID, Orders.UserID, Order_Product.Amount, Orders.Total, Product.ProductID, Product.ProductName, Product.ProductPrice FROM Orders inner join Order_Product on Orders.OrderID = Order_Product.OrderID INNER JOIN Product ON Order_Product.ProductID = Product.ProductID WHERE UserID = @UserID AND Orders.OrderID = @OrderID";


        //        //Kan nu alles voor elk user ophalen maar moet gelijk zijn aan userID en orderID.
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(query, connection);
        //            cmd.Parameters.Add(new SqlParameter("@UserID", UserId));
        //            cmd.Parameters.Add(new SqlParameter("@OrderID", Order.OrderId));

        //            connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Product product = new Product();
        //                product.ProductID = Convert.ToInt32(reader["ProductID"]);
        //                product.Productname = reader["ProductName"].ToString();
        //                product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
        //                product.Amount = Convert.ToInt32(reader["Amount"]);
        //                //order.Date = Convert.ToDateTime(reader["Date"]);
        //                //order.Total = Convert.ToInt32(reader["Total"]);
        //                GetProductList.Add(product);
        //            }

        //            return GetProductList;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public void DeletCartTable(Order order)
        {
            string query = "DELETE FROM Cart WHERE userID = @UserID";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserID", order.User.UserID));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }

        //public List<Order> OrderList(int UserId)
        //{
        //    try
        //    {
        //        List<Order> GetProductList = new List<Order>();

        //        string query = "SELECT Orders.OrderID, Orders.UserID, Order_Product.Amount, Orders.Total, Product.ProductID, Product.ProductName, Product.ProductPrice FROM Orders inner join Order_Product on Orders.OrderID = Order_Product.OrderID INNER JOIN Product ON Order_Product.ProductID = Product.ProductID WHERE UserID = @UserID AND Orders.OrderID = 20";


        //        //Kan nu alles voor elk user ophalen maar moet gelijk zijn aan userID en orderID.
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(query, connection);
        //            cmd.Parameters.Add(new SqlParameter("@UserID", UserId));
        //            //cmd.Parameters.Add(new SqlParameter("@OrderID", OrderID));

        //            connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {

        //                Order order = new Order();
        //                order.ProductID = Convert.ToInt32(reader["ProductID"]);
        //                product.Productname = reader["ProductName"].ToString();
        //                product.Productprice = Convert.ToDouble(reader["ProductPrice"]);
        //                product.Amount = Convert.ToInt32(reader["Amount"]);
        //                //order.Date = Convert.ToDateTime(reader["Date"]);
        //                //order.Total = Convert.ToInt32(reader["Total"]);
        //                GetProductList.Add(product);
        //            }

        //            return GetProductList;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
