using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    class days
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the day number");
            int t = Convert.ToInt32(Console.ReadLine());
            if (t == 0)
                Console.WriteLine("sunday");
            else if (t == 1)
                Console.WriteLine("Monday");
            else if (t == 2)
                Console.WriteLine("Tuesday");
            else if (t == 3)
                Console.WriteLine("Wednesday");
            else if (t == 4)
                Console.WriteLine("Thursday");
            else if (t == 5)
                Console.WriteLine("Friday");
            else if (t == 6)
                Console.WriteLine("Saturday");
            else 
                Console.WriteLine("enter number below 7 only");

           Console.Read();


        }
       
    }
}
