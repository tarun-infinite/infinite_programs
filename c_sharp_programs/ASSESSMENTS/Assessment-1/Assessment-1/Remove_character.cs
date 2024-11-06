using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Remove_character
    {
        public static void Main()
        {
            Console.WriteLine("enter string: ");
            string s = Console.ReadLine();
            // int k = s.Length;
            Console.WriteLine("enter index value: ");
           int k= Convert.ToInt32(Console.ReadLine());
            //string t = s.RemoveAt(k);
            s = s.Remove(k,1);
            Console.WriteLine(s);
            
            //Console.Read();
            //Console.WriteLine(s[1]);
            //Console.WriteLine(s);
            Console.Read();

        }
    }
}
