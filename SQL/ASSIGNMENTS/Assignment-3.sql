select * from Employee
select * from Dept

/*1. Retrieve a list of MANAGERS. 
2. Find out the names and salaries of all employees earning more than 1000 per 
month. 
3. Display the names and salaries of all employees except JAMES. 
4. Find out the details of employees whose names begin with ‘S’. */

select ename as list_of_managers from Employee where job = 'MANAGER'

select ename from Employee where salary>1000s

select ename,salary as salaries from Employee where ename != 'james'

select ename as names from Employee where ename like 'S%'

/*5. Find out the names of all employees that have ‘A’ anywhere in their name. 
6. Find out the names of all employees that have ‘L’ as their third character in 
their name. 
7. Compute daily salary of JONES. 
8. Calculate the total monthly salary of all employees. 
9. Print the average annual salary . */

select ename  from Employee where ename like '%A%'

select ename from Employee where ename like '__L%'

select salary/30 as salaty_of_jones from Employee where ename ='JONES'

select sum(salary) as TOTAL_SUM from Employee 

select avg(salary) from Employee

/*10. Select the name, job, salary, department number of all employees except 
SALESMAN from department number 30. 
11. List unique departments of the EMP table. 
12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
 */

select ename,job,salary,deptno from Employee where job!='salesman' or Deptno!=30

select distinct(job) from employee

select ename as Employee_name , salary as SAL from Employee where salary>1500 and (Deptno=10 or Deptno= 30)

/*13. Display the name, job, and salary of all the employees whose job is MANAGER or 
ANALYST and their salary is not equal to 1000, 3000, or 5000. 
14. Display the name, salary and commission for all employees whose commission 
amount is greater than their salary increased by 10%.
15. Display the name of all employees who have two Ls in their name and are in 
department 30 or their manager is 7782. */

select ename,job,salary from Employee where( job='manager' or job='analyst') and (salary!=1000 and salary!=3000 and salary!=5000)

select ename,salary,comm+comm*0.1 as commision  from employee  where comm>salary

select ename from employee where ename like' %L%L%' and (Deptno=30 OR Mgr_Id=7782)

/*16. Display the names of employees with experience of over 30 years and under 40 yrs.
 Count the total number of employees. 
17. Retrieve the names of departments in ascending order and their employees in 
descending order. 
18. Find out experience of MILLER. */

select DATEDIFF(year,hiredate,getdate()) as experience from Employee where ename='miller'

select ename from Employee where DATEDIFF(year,hiredate,getdate()) between 30 and 40
select count(*) from Employee where DATEDIFF(year,hiredate,getdate()) between 30 and 40

select ename ,dname from employee join dept on employee.deptno=dept.deptno order by dname asc,ename desc