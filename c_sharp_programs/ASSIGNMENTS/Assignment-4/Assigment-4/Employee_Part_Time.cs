﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_4
{
    class Employee
    {
        public int EmpId;
        public string EmpName;
        public float Salary;
        public Employee(int eid, string ename, float sal)
        {

            EmpId = eid;
            EmpName = ename;
            Salary = sal;

        }
        public void Display()
        {
            Console.WriteLine("Employee id is  " + EmpId + ",Employee name is  " + EmpName + "Employee salary is " + Salary);
        }
    }


    class Employee_Part_Time : Employee
    {
        int Wages;
        public Employee_Part_Time(int eid, string ename, float sal) : base(eid, ename, sal)
        {

        }
        public static void Main()
        {
            Console.WriteLine("Enter employye id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter salary of employee");
            float salaryy = (float)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Employee class constructor");
            Employee e1 = new Employee(id, name, salaryy);
            e1.Display();
            Employee_Part_Time p1 = new Employee_Part_Time(id, name, salaryy);
            p1.Display();
            Console.Read();
        }

    }

 }
    

