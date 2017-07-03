/*
General.InsertProfile.sql
*/

if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[General].[InsertProfile]')
	and objectproperty(id, N'IsProcedure') = 1))
	begin
		drop procedure [General].[InsertProfile];
	end;
go

create procedure [General].[InsertProfile]
(
	@userName varchar(20),
	@platformId int,
	@regionId int
)
as

set nocount on;
set transaction isolation level read committed;

if(not exists(
	select *
	from General.UserProfile
	where UserName = @userName
		and RegionId = @regionId
		and PlatformId = @platformId))
begin
	insert into General.UserProfile
	(
		ProfileGuid, 
		UserName, 
		RegionId, 
		PlatformId
	)
	values
	(
		newid(), 
		@userName, 
		@regionId, 
		@platformId
	)
end