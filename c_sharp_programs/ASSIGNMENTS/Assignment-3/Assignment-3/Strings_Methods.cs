using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Strings_Methods
    {
        static void Main(string[] args)
        {
            Console.Write("enter the word : ");
            String s = Console.ReadLine();
            int a = 0;
            char c;
            
            foreach(char i in s)
            {
                a = a + 1;
            }
            //char[] b = new char[a];
            string b = "";
            foreach (char i in s)
            {
                b = i + b;
            }
            Console.WriteLine("The length of string is :{0} : ", a);
            Console.WriteLine(" Reverse of string is {0} : ", b);
            Console.Write("enter the word2 : ");
            String s2 = Console.ReadLine();
            if (s.Length == s2.Length)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != s2[i])
                    {
                        Console.WriteLine("Both are not equal");
                        break;
                    }
                    // else { Console.WriteLine("Both words {0} and {1} are equal", s, s2); }

                }
                Console.WriteLine("Both words {0} and {1} are equal", s, s2);
                 
            }
            else { Console.WriteLine("not equal"); }

            Console.Read();
        }
    }
}
