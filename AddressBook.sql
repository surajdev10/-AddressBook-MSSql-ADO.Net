---UC_1 Create a Address Book Service DB
create database AddressBookService;
use AddressBookService;

---UC_2 create a AddressBook Table
create table AddressBookTable(
First_name varchar(255),
Last_name varchar(255),
Address varchar(255),
City varchar(255),
State varchar(255),
Zip int,
Phone_number bigint,
Email varchar(255));

---UC_3 Insert Data In Table
insert into AddressBookTable
values ('Amit','Kumar','Denkanal','Denkanal','Odisha',567465,7978861488,'ak@gmail.com'),
('Akanksha','Kumari','Jajpur','Jajpur','Gujarat',561035,87461284512,'akanksha@gmail.com');

---UC_4 Edit the existing contact
update AddressBookTable set Zip = 985625 where First_name = 'Akanksha';
select * from AddressBookTable;

---UC_5 Delete person from table
delete from AddressBookTable where First_name = 'Akanksha';

----UC_6 Retrieve data using City name
insert into AddressBookTable
values ('Abhilash','Mahanty','sundergarth','Bhuvneswar','Odisha',846723,84567855554,'abhilash@gmail.com'),
('Rohit','Patel','Ahemdabad','Ahemdabad','Gujarat',8644765,84678546565,'rohit@gmail.com');
insert into AddressBookTable
values ('Akanksha','Lanjewar','Nagpur','Nagpur','Maharastra',561235,87451284512,'akanksha@gmail.com');
select * from AddressBookTable where city = 'Denkanal';
select * from AddressBookTable where state = 'Gujarat';

---UC_7 the size of address book by City and State
select count(city) from AddressBookTable ;
select count(State) from AddressBookTable ;
select City,count(First_name) from AddressBookTable group by City;
select State,count(First_name) from AddressBookTable group by State;

---UC_8 retrieve entries sorted alphabetically by Person’s name for a given city
insert into AddressBookTable
values ('Papun','Nayak','Denkanal','Denkanal','Odisha',360530,98461532455,'lisan@gmail.com');
select * from AddressBookTable where City = 'Denkanal' order by First_name;

---UC_9 Add one more colum of 'type'
alter table AddressBookTable add Type varchar(50);
update AddressBookTable set Type = 'Friends' where First_name = 'Amit' or First_name = 'Abhilash';
update AddressBookTable set Type = 'Family' where First_name = 'Rohit' or First_name = 'Akanksha';
update AddressBookTable set Type = 'Profession' where First_name = 'Papun';
select * from AddressBookTable;

---UC_10 get number of contact persons i.e. count by type
select Type,count(First_name) as TotalPersons from AddressBookTable group by Type;
select count(Type) as Total_Number_of_person from AddressBookTable;