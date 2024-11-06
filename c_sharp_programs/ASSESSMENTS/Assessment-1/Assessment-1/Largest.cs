using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Largest

    {

        //public int a;
        //public int b;
        //public int c;
        static void Main(string[] args)
        {
            //int a;
            //int b;
            //int c;
            Console.WriteLine("enter the numbers");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            //int max = 0;
            if (a > b && a > c)
            {
                Console.WriteLine(a);
                Console.Read();
            }
            else if (b > a && b > c)
            {
                Console.WriteLine(b);
                Console.Read();
            }
            else
            {
                Console.WriteLine(c);
                Console.Read();
            }
            Console.Read();


        }




    }
}

