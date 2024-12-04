use TarunDB
--1.	Write a query to display your birthday( day of week)
--2.	Write a query to display your age in days
 select * from employee
 select * from dept

select  datename(weekday,'05-08-1986') as Gambhir_birthday



declare @dob date ='05-08-2003';
select datediff(day,@dob,getdate()) as total_days
 
 

 

 
 
 
/*3.	Write a query to display all employees information those who joined before 5 years in the current month
 
(Hint : If required update some HireDates in your EMP table of the assignment)*/


select * from Employee
       where year(getdate()) - year(hiredate) > 5
       And month(hiredate) = month(getdate());
 





 
/*4.	Create table Employee with empno, ename, sal, doj columns or use and perform the following operations in a single transaction
	a. First insert 3 rows 
	b. Update the second row sal with 15% increment  
    c. Delete first row.
After completing above all actions, recall the deleted row without losing increment of second row.*/


CREATE TABLE employee2 (
    empno INT,
    ename VARCHAR(50),
    sal DECIMAL(10),
    doj DATE
);
 
begin transaction

INSERT INTO Employee2
VALUES 
(1, 'tarun', 1200, '2020-01-15'),
(2, 'arthi', 1400, '2021-03-10'),
(3, 'sivaa', 1600, '2022-07-20');
select * from employee2
 
-- b. Update the second row salary with a 15% increment
UPDATE Employee2
SET sal = sal * 1.15
WHERE empno = 2;
 
-- c. Delete the first row
DELETE FROM Employee2
WHERE empno = 1;
 
rollback
 
commit

SELECT * FROM Employee2;
 



















 
/*5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	a.     For Deptno 10 employees 15% of sal as bonus.
	b.     For Deptno 20 employees  20% of sal as bonus
	c      For Others employees 5%of sal as bonus*/


CREATE FUNCTION Cal_Bonus1 (@deptNo INT, @salary DECIMAL(10, 2))

RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @bonus DECIMAL(10, 2);
    IF @deptNo = 10
        SET @bonus = @Salary * 0.15;
    ELSE IF @DeptNo = 20
        SET @bonus = @Salary * 0.20;
    ELSE
        SET @bonus = @Salary * 0.05;
 
    RETURN @bonus;
END;

SELECT
    empno
    ename,
    DeptNo,
    Salary,
    dbo.Cal_Bonus1(DeptNo, Salary) AS Bonus
FROM
    Employee;











 
/*6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
has context menu*/


create or alter proc updateSal
as
begin
update e
set e.salary = e.salary+ 500 
from employee e
Join DEPT D ON e.DeptNo = d.Deptno
where d.Dname = 'Sales' and e.salary < 1500;
end
 
exec updateSal;
select * from Employee


