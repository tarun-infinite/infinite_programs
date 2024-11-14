using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class File_Inside_Array
    {
       
            // Write a program in C# Sharp to create a file and write an array of strings to the file.
            static void Main()
            {
            Console.WriteLine("Enter the size");
            int sz = Convert.ToInt32(Console.ReadLine());
                string[] str = new string[sz];
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write($"Enter string {i + 1} : ");
                    str[i] = Console.ReadLine();
                }
                string path = "Tarun_Kumar.txt";
                FileStream filestrem = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter streamwriter = new StreamWriter(filestrem);
                foreach (string s in str)
                {
                    streamwriter.WriteLine(s);
                }
                Console.WriteLine("Written to the file Successfully");
                streamwriter.Flush();
                streamwriter.Close();
                filestrem.Close();
                Console.ReadLine();
            }
        }
    }

