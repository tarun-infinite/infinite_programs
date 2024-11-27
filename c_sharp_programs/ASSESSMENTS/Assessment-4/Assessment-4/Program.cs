using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4
{
    
    public class Employee
    {
        public int EmployeeID { 
            get;
            set; 
        }
        public string FirstName {
            get;
            set; 
        }
        public string LastName { 
            get; 
            set; 
        }
        public string Title {
            get; 
            set; 
        }
        public DateTime DOB { 
            get;
            set;
        }
        public DateTime DOJ { 
            get; 
            set;
        }
        public string City { 
            get; 
            set; 
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Creating the list of employees
            List<Employee> empList = new List<Employee>
{
new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1994, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
};

            

    
            Console.WriteLine("-----query-1-------");
            var allEmployees = empList;
            Console.WriteLine("Details of all employees ");
            foreach (var emp in allEmployees)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title} {emp.DOB.ToShortDateString()} {emp.DOJ.ToShortDateString()} {emp.City}");
            }

       
            Console.WriteLine("--------query-2-------");
            var nonMumbaiEmployees = empList.Where(e => e.City != "Mumbai");
            Console.Write("\nEmployees Not in Mumbai:");
            foreach (var emp in nonMumbaiEmployees)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.City}");
            }

            
            Console.WriteLine("---------query-3--------");
            var asstManagers = empList.Where(e => e.Title == "AsstManager");
            Console.WriteLine("\nAsstManagers:");
            foreach (var emp in asstManagers)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title}");
            }


            Console.WriteLine("--------query-4---------");
            var employeesWithS = empList.Where(e => e.LastName.StartsWith("S"));
            Console.WriteLine("\nEmployees Whose Last Name Starts with 'S':");
            foreach (var emp in employeesWithS)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName}");
            }
            Console.ReadLine();
        }
    }
    
}
