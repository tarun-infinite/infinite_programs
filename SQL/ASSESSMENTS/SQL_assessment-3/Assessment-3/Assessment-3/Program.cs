using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter prod");
            string pname = Console.ReadLine();
            Console.WriteLine("price");
            float price = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(@"Data Source=ICS-LT-D244D67P;Initial Catalog=TarunDB;" +
                "Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("update_products", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productname", pname);
                    cmd.Parameters.AddWithValue("@price", price);
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@productId";
                    parameter.DbType = DbType.Int32;
                    parameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameter);
                    cmd.ExecuteNonQuery();
                    int productid = (int)parameter.Value;
                    float discprice = (float)(price - ((price) * 10 / 100));
                    
                    Console.WriteLine($"Generated Id : {productid}");
                    Console.WriteLine($"Discounted price : {discprice}");
                }
            }

            Console.ReadLine();
        }
    }
}