using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKS
{
    class progrm5
    {
        public static void Main()
        {
            Console.WriteLine("enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{a} *{i}={ a*i}");
            }
            Console.Read();
        }
       
    }
}
