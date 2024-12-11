use TarunDB

create table courseedetails
(
c_id varchar(20),
c_name varchar(20),
start_datee date,
end_date date,
fee int
)

insert into courseedetails values
('DN003','dotnet','2018-02-01','2018-02-28',15000),
('DV004','datavisualization','2018-04-15','2018-04-15',15000),
('JA002','advancedjava','2018-01-02','2018-01-20',10000),
('JC001','corejava','2018-01-02','2018-01-12',3000)

select * from courseedetails

--Create a Function to calculate the course duration for the above relation by receiving start date and end date as input.

create function CalculateCourseDuration(@start_date DATE, @end_date DATE)
returns int
as
begin 
return
     DATEDIFF(day, @start_date, @end_date);
end;

select dbo.CalculateCourseDuration('2018-01-20', '2018-01-02') AS DurationInDays;



--Create a trigger to display the Course Name and Start date of the course

create table t_courseinfoo(c_name varchar(20),start_date date)


create trigger Update_courseInfoo   
on CourseDetails
after insert
as
begin
    Insert into T_CourseInfoo(C_Name,Start_Date)
    select C_Name,Start_Date from inserted;
end
 

insert into CourseDetails values('DV900','Machine_learning','2020-11-05','2021-01-17',1000)  

select*from T_CourseInfoo;

--Write a stored Procedure that inserts records in the ProductsDetails table



create table ProductsDetails(ProductId int identity , ProductName varchar(30), Price Float, DiscountedPrice Float);

create or alter procedure update_products  @productname varchar(30),@price int,@productId int output
as
begin
insert into ProductsDetails(ProductName,Price) values(@productname,@price)
set @productId=SCOPE_IDENTITY();
end
 
