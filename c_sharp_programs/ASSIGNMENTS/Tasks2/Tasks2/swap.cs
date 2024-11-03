using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter first number");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter second  number");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"before swap a={a} and b={b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.Write($"after swap a= {a} and b={b}");
            Console.Read();


        }
    }
}
