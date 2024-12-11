using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Employee
    {
        public int EmployeeID;
        public string FirstName;
        public string LastName;
        public string Title;
        public DateTime DOB;
        public DateTime DOJ;
        public string City;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
              {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla",Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla",Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai"},
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza",Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh",Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh",Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak",Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan",Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey",Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry",Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah",Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };


            Console.WriteLine("-----------Display the list of all the employees who have joined before 1 / 1 / 2015------------");
            var op1 = employees.Where(e => e.DOJ < new DateTime(2015, 1, 1)).Select(n => n);
            foreach (var i in op1)
            {
                Console.WriteLine($" Employee Name : {i.FirstName}{i.LastName} , DOJ : {i.DOJ.ToShortDateString()}");
            }


            Console.WriteLine("----------Display the list of all the employees whose date of birth is after 1/1/1990-----------");
            var op2 = employees.Where(e => e.DOB > new DateTime(1990, 1, 1)).Select(n => n);
            foreach (var i in op2)
            {
                Console.WriteLine($"Employee Name : {i.FirstName}{i.LastName}, DOB : {i.DOB.ToShortDateString()}");
            }



            Console.WriteLine("-----------Display the list of all the employees whose designation is Consultant and Associate-----------");
            var op3 = employees.Where(e => e.Title == "Consultant" || e.Title == "Associate").Select(n => n);
            foreach (var i in op3)
            {
                Console.WriteLine($"Employee Name : {i.FirstName}{i.LastName} , Title : {i.Title}");
            }


            Console.WriteLine("-------Display total number of employees------------");
            var op4 = employees.Count();
            Console.WriteLine("Number of Employees : {0} ", op4);


            Console.WriteLine("-------Display total number of employees belonging to Chennai------");
            var op5 = employees.Where(e => e.City == "Chennai").Count();
            Console.WriteLine("Number of Employees : {0} ", op5);



            Console.WriteLine("-------Display highest employee id from the list-------");
            var op6 = employees.Select(e => e.EmployeeID).Max();
            Console.WriteLine("Highest employee id : {0} ", op6);


            Console.WriteLine("-----------Display the list of all the employees who have joined after 1 / 1 / 2015------------");
            var op7 = employees.Where(e => e.DOJ > new DateTime(2015, 1, 1)).Select(n => n);
            foreach (var i in op7)
            {
                Console.WriteLine($"Employee Name : {i.FirstName}{i.LastName},DOJ : {i.DOJ.ToShortDateString()} ");
            }


            Console.WriteLine("-----------Display total number of employees whose designation is not Associate-----------");
            var op8 = employees.Where(e => e.Title != "Associate").Count();
            Console.WriteLine("Total number of employees whose designation is not Associate : {0}", op8);


            Console.WriteLine("---------Display total number of employees based on City-----------");
            var op9 = employees.GroupBy(e => e.City);
            foreach (var i in op9)
            {
                Console.WriteLine($"{i.Key} : {i.Count()}");
            }


            Console.WriteLine("---------Display total number of employees based on city and title-------------");
            var op10 = employees.GroupBy(e => (e.City, e.Title));
            foreach (var i in op10)
            {
                Console.WriteLine($"{i.Key.City} , {i.Key.Title}: {i.Count()}");
            }


            Console.WriteLine("---------Display the details of employee who is youngest in the list----------");
            var op11 = employees.OrderBy(e => e.DOB).Last();
            Console.WriteLine($"Employee Id : {op11.EmployeeID} , Employee Name : {op11.FirstName}{op11.LastName} , Title : {op11.Title}, DOB : {op11.DOB.ToShortDateString()}, DOJ : {op11.DOB.ToShortDateString()} , City : {op11.City}");
            Console.Read();
        }
    }
}