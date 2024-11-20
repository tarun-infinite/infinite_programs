using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
   
        class Program
        {
            static void Main(string[] args)
            {
                string file = "file.txt";
                Console.WriteLine("Enter a Text to Append to the existing file");
                string text = Console.ReadLine();
                if (File.Exists(file))
                {
                    File.AppendAllText(file, text + "\n");

                }
                else
                {
                    File.WriteAllText(file, text + "\n");
                }
                Console.WriteLine("---------- solution using StreamWriter---------------");
                using (StreamWriter str = new StreamWriter(file, append: true))
                {
                    str.Write(text + "\n");
                }
                Console.WriteLine("Text has been appended Succesfully");
                Console.ReadLine();
            }
        }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "Tarunkumar.txt";
            Console.WriteLine("enter the necessary text you want to enter");

            string txt = Console.ReadLine();

            try
            {
                if (File.Exists(filename))
                {
                    File.AppendAllText(filename, txt + "\n");

                }
                else
                {
                    File.WriteAllText(filename, txt + "\n");
                }
                using (StreamWriter writer = new StreamWriter(filename, append: true))
                {
                    writer.WriteLine(txt);

                }
                Console.WriteLine("Text  has written");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"an error occured :{ex.Message}");
            }
            Console.Read();
        }
    }
}

