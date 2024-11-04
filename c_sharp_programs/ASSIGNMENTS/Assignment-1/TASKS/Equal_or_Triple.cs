using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKS
{
    class problem4
    {
        public static void Main()
        {
            int a =Convert.ToInt32(Console.ReadLine());

            int b= Convert.ToInt32(Console.ReadLine());
            if (a != b) Console.WriteLine(a + b);
            else Console.WriteLine(3 * (a + b));
            Console.Read();

        }
    }
}
