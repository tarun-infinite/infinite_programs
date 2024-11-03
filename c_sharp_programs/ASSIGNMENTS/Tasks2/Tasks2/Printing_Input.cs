using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    class Printing_Input
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the digit");
            string c=Console.ReadLine();
            for (int i = 0; i <= 3; i++)
            {
                if(i%2==0)
                    Console.WriteLine("{0} {0} {0} {0}", c);
                else
                    Console.WriteLine("{0}{0}{0}{0}", c);
                
                Console.WriteLine();

            }
            Console.Read();
        }

    }
}
