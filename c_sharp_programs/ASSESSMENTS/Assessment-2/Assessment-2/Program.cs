using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
     class Product
    {
        public int ProductId
        {
            get;
            set;
        }
        public string ProductName
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;

        }
        public Product (int productId,string productName,decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID:{ProductId},Name:{ProductName},Price:{Price:c}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.WriteLine("enter number of products");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("enter details for product{i+1}:");
                Console.WriteLine("product id: ");
                int productId = int.Parse(Console.ReadLine());
                Console.WriteLine("product Name : ");
                string productName = Console.ReadLine();
                Console.WriteLine("product prices : ");
                decimal price = decimal.Parse(Console.ReadLine());
                products.Add(new Product(productId, productName, price));
                Console.WriteLine();
            }
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            Console.WriteLine("products sorted by price :");
            foreach(var product in sortedProducts)
            {
                Console.WriteLine(product);

            }
            Console.Read();
        }
    }
}
