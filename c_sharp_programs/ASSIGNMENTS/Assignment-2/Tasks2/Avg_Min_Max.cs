using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    class Avg_Min_Max
    {
        static void Main(string[] args)
        {
            Console.WriteLine("size:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for(int i = 0; i < size ; i++)
            {
                Console.WriteLine($"arr[{i}]:");
              arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            for (int i= 0;i < size;i++)
            {
                sum += arr[i];
            }
            int avg = (sum / size);
           int  min = arr[0];
            int max = arr[0];
            for (int i = 0; i < size; i++)
            {
                if (arr[i] < min)
                min = arr[i];
            }
            for (int i = 0; i < size; i++)
            {
                if (arr[i] > max)
                    max = arr[i];

            }
            Console.WriteLine($"average is {avg},minimm is {min}, maximum is {max}");
            Console.Read();

        }
    }
}
