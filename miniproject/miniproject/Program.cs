using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject
{
    class Program
    {
        // static string connectionString = "Server=ICS-LT-D244D67P;Database=mini_project;Trusted_Connection=True;";

       public static void Main()
        {
            Console.WriteLine("*********WELCOME TO RAILWAY RESERVATION SYSTEM************");
            Console.WriteLine("enter your choice \n 1.ADMIN \n 2.USER \n 3.EXIT  ");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (choice == 1     )
                {
                    Admin_Class.AdminMenu();
                }
                else if (choice == 2)
                {
                   
                    userclass.usermenu();
                }
                else if (choice==3)
                {
                    
                    Console.WriteLine("EXITING THE RAILWAY RESERVATION SYSTEM");
                    break;
                    //Program.Main();
                }
                else
                {
                    Console.WriteLine("entered invalid option");
                    Main();
                }
            }
        }
    }
}


