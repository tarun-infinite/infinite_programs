using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public delegate int Calculator(int x, int y);
    class Calculator_Using_Delegates
    {
        static int Add(int x, int y) => x + y;
        static int Subtract(int x, int y) => x - y;
        static int Multiply(int x, int y) => x * y;
        static void Calculate( Calculator calc, string operation)
        {
            Console.WriteLine($"enter 1st number for {operation} : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"enter 2nd  number for {operation} : ");
            int y = Convert.ToInt32(Console.ReadLine());
            int res = calc(x, y);
            Console.WriteLine($"{operation} result :{res}");

        }
        static void Main()
        {
            Console.WriteLine(" OPERATIONS IN CALCULATOR");
            Calculator calcAdd = Add;
            Calculate(calcAdd, "Addition");
  l         Calculator calcSubtract = Subtract;
            calculate(calcSubtract, "Subtraction");
            Calculator calcMultiply = Multiply;
            Calculate(calcMultiply, "Multiplication");


        }



    }
}
