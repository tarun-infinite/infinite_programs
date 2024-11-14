using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class File_Lines_Count
    {
      static void Main()
            {
            string path = @"C:\dotnet_training\c_sharp_programs\ASSIGNMENTS\Assignment-5\Assignment-5\bin\Debug";
                Console.WriteLine(" * ** Original Path ***");
                if (File.Exists(path))
                {
                    int count = File.ReadAllLines(path).Length;
                    Console.WriteLine($"Given path have {count} lines");
                }
                else Console.WriteLine("Given path doesn't exists");
                Console.WriteLine();

                // Duplicate path 
                string path1 = "@C:\\Infinite_Training\\C_Sharp\\C#.txt";

                Console.WriteLine("*** Duplicate Path ***");
                if (File.Exists(path1))
                {
                    int count = File.ReadAllLines(path1).Length;
                    Console.WriteLine($"Given path have {count} lines");
                }
                else Console.WriteLine("Given path doesn't exists");

                Console.ReadLine();
            }
        }
    }

