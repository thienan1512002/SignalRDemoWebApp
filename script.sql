Create database SignalRDemo
go 
use SignalRDemo
go
create table Notyf(
	id int primary key identity , 
    username varchar(50) , 
	content varchar(50),
	timeCreate varchar(50),
)
go

