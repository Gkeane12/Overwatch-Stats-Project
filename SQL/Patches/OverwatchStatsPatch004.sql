/*
OverwatchStatsPatch004.sql
Adding Sr value to the Combat.Competitive Table
giving all previous values 0
*/
alter table Combat.Competitive
	add SR int;
go

update Combat.Competitive
	set SR = 0;
go

alter table Combat.Competitive
	alter column SR int not null;