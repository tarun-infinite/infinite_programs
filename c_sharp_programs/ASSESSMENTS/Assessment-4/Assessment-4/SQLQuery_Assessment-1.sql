create database SQL_Assessment
use SQL_Assessment

create table books(
id int primary key,
title varchar(40)not null,
author varchar(20)not null,
isbn varchar(20),
published_date date
)

insert into books values(1, 'My_First_SQL_book', 'MaryParker','981483029127','2012-02-22 12:08:17'),
(2, 'My Second book', 'John Mayer','857300923713','1972-07-03 09:22:45'),
(3,'My Third book','Cray Flint','523120967812','2015-10-18 14:05:44')
select * from books

--Write a query to fetch the details of the books written by author whose name ends with er.

select * from books where author like '%er' 



create table reviews(
id int references books(id),
book_id int not null,
reviewer_name varchar(40) not null,
content varchar(40) not null,
rating int,
published_date varchar(40) not null
)

insert into reviews values (1,1,'John Smith','My first review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith',' My second review','5','2017-10-13 15:05:12'),
(3,2,'Alice walker','Another review','1','2017-10-22 23:47:10')

--Display the Title ,Author and ReviewerName for all the books from the above table
 

select title,author,reviewer_name from books join reviews on books.id=reviews.id

--Display the  reviewer name who reviewed more than one book.

select reviewer_name from reviews where book_id is not null
group by reviewer_name
having count(distinct( book_id))>=2



create table customers(
id int primary key,
name varchar(40),
age int,
adress varchar(40),
salary float)

insert into customers values(1,'ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'delhi',1500.00),
(3,'kaushik',23,'kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',85000),
(6,'komal',22,'Mp',4500.00),
(7,'Muffy',24,'Indore',10000.00)

select * from customers

--Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
  
select name,adress from customers where adress like'%o%'




create table orders(
Oid int,
Date date not null,
customer_id int references customers(id)  not null,
amount int
)

insert into orders values(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(103,'2008-05-20 00:00:00',4,2060)


--Write a query to display the   Date,Total no of customer  placed order on same Date

select date,count(customer_id) as total_count from orders group by Date



create table customers1(
id int primary key,
name varchar(40),
age int,
adress varchar(40),
salary float)

insert into customers1 values(1,'ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'delhi',1500.00),
(3,'kaushik',23,'kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',85000),
(6,'komal',22,'Mp',null),
(7,'Muffy',24,'Indore',null)
select * from customers1

--Display the Names of the Employee in lower case, whose salary is null
 
select LOWER(name) as  [no salary people] from customers1  where salary is null




create table Student_details
(
Register_no int primary key,
Name varchar(30) not null,
Age int not null,
Qualification varchar(20),
Mobile_no float not null,
Mail_id varchar(30),
locationn varchar(30),
Gender varchar(1)
)
 
 
insert into Student_details values
(2,'Sai',22,'B.E',9952836779,'sai@gmail,com','Chennai','M'),
(3,'Kumar',20,'BSC',7252836779,'kumar@gmail,com','Madurai','M'),
(4,'Selvi',22,'B.TECH',8952836779,'selvi@gmail,com','Selam','F'),
(5,'Nisha',25,'M.E',6352836779,'nisha@gmail,com','Theni','F'),
(6,'SaiSaran',21,'B.A',9865836779,'saisaran@gmail,com','Madurai','F'),
(7,'Tom',23,'BCA',6552836779,'tom@gmail,com','Pune','M')
 
select * from Student_details
 
-- Write a sql server query to display the Gender,Total no of male and female from the above relation  
 
select Gender,count(*) as Total_count from Student_details group by Gender
