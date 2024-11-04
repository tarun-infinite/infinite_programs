using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input 1st number");
            int a= Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Input 2nd number");
           int b =Convert.ToInt32(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine($"{a} and {b} are equal");
                Console.Read();
            }
            else
            {
                Console.WriteLine($"{a} and {b} are not  equal");
                Console.Read();
            }
        }
    }
}
