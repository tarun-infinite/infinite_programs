using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    class Handson
    {
        static int counter = 0;
        static readonly object lockObject = new object();

        static void Main()
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Final counter value " + counter);
            Console.Read();
        }
        static void IncrementCounter()
        {
            for (int i = 0; i < 5000; i++)
            {
                lock (lockObject)
                {
                    counter++;
                }
            }
        }
    }
}