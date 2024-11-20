using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public class Box
    {
        public int Length
        {
            get;
            set;
        }
        public int Breadth
        {
            get;
            set;
        }
        public Box(int length,int breadth)
        {
            Length = length;
            Breadth = breadth;

        }
        public static Box operator +(Box b1 ,Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);

        }
        public override string ToString()
        {
            return $"length :{Length}\n  breadth : {Breadth}";
        }
    }
    class Test
    {
        static void Main()
        {
            Console.Write("Enter Length of box 1 : ");
            int l1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter breadth of box 1 : ");
            int b1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Length of box 2 : ");
            int l2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter breadth of box 2 : ");
            int b2 = Convert.ToInt32(Console.ReadLine());
            Box box1 = new Box(l1, b1);
            Box box2 = new Box(l2, b2);
            Box box3 = box1 + box2;
            Console.WriteLine("===AFTER ADDING USING OBJECTS===");
            Console.WriteLine("Box 1 :" + box1);
            Console.WriteLine("Box 2 :" + box2);
            Console.WriteLine("Box 3 :(Sum): " + box3);
        }
    }

}
