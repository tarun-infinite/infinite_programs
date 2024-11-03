using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    class copy
    {
        static void Main()
        {
            int[] arr1 = new int[] { 5, 2, 3, 1, 4 };
            int len = arr1.Length;
            int[] arr2 = new int[len];
            Console.WriteLine("new array after copied");
            for (int i = 0; i < len; i++)
            {
                arr2[i] = arr1[i];
            }
            foreach (int i in arr2)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
    }
}
