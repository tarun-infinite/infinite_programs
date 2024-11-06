using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Number_of_times
    {
        
            static void Main(string[] args)
            {
                Console.WriteLine("enter a string ");
                string s = Console.ReadLine();
                char[] c = s.ToCharArray();


                for (int i = 0; i < c.Length; i++)
                {
                    char ch = c[i];
                    if (ch == '$')
                        continue;
                    int count = 0;
                    for (int j = i + 1; j < c.Length; j++)
                    {
                        if (ch == c[j])
                        {
                            count++;
                            c[j] = '$';

                        }
                    }
                    ch = '$';
                    Console.WriteLine("the count of count of " + c[i] + " is " + count);
                    Console.ReadLine();


                }
            }
        }
    }

