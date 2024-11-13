using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    class Check_Negative
    {
        static void CheckIfNegative(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("the number cannot be negative");
            }
            else
            {
                Console.WriteLine("the number is positive");
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter the number");
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckIfNegative(number);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Exception :" + ex.Message);
            }
            catch (FormatException) // must pass a integer value as input not alphabets and symbols
            {
                Console.WriteLine(" enter a proper valid integer");
            }
            Console.Read();
        }
    }
}
