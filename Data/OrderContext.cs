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


        public void PlaceOrder(Cart order, int UserId)
        {
            DateTime date;
            string query = $"INSERT INTO Orders(UserID, ProductID, Amount, Total, Date) VALUES(@UserId, @ProductId, @Amount, @Total, @Date)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    cmd.Parameters.Add(new SqlParameter("@ProductId", order.Product.ProductID));
                    cmd.Parameters.Add(new SqlParameter("@Amount", order.Amount));
                    cmd.Parameters.Add(new SqlParameter("@Total", order.SubTotal));
                    //cmd.Parameters.Add(new SqlParameter("@Date", date));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
