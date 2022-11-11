Create Table clients(
	id Int not null Primary Key Identity,
	namec varchar(100) Not null,
	email varchar(100) not null,
	phone varchar(20) not null,
	address varchar(100) not null,
	createdAt Datetime not null Default Current_Timestamp

);

Insert Into clients(namec, email,phone,address)
VAlues('ashok','ashok@gmail.com',2345,'beed'),
('vivek','vivek@gmail.com',9875,'wai'),
('akash','akash@gmail.com',8905,'satara')

select * from clients;