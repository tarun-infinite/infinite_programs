using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Exchange
    {
        public void change(string str)
        {
            string s = "";
            int l = str.Length;
            string a = Convert.ToString(str[0]);
            string b = Convert.ToString(str[l - 1]);
            s += a;
            for (int i = 1; i < str.Length - 1; i++)
            {
                s = s + str[i];
            }
            s += b;
            Console.WriteLine("result {0}", s);


        }
        static void Main()
        {
            Exchange obj = new Exchange();
            Console.WriteLine("enter :");
            string str = Console.ReadLine();
            obj.change(str);
            Console.Read();
           


           
           

            



        }
    }
}

