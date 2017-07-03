/*
DatabaseCreate.Sql --- Initialise Database Patch
*/

declare @dbname nvarchar(16);
set @dbname = N'Overwatch';

if(not exists(select name 
	from master.dbo.sysdatabases
	where ('[' + name + ']' = @dbname
		or name = @dbname)))
	begin
		create database Overwatch;
	end