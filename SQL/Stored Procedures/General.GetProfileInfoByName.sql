/*
General.GetProfileInfoByName.sql
*/
if(exists(
	select * 
	from sys.sysobjects
	where id = object_id(N'[General].[GetProfileInfoByName]')
		and objectproperty(id, N'IsProcedure') = 1))
		begin
			drop procedure [General].[GetProfileInfoByName];
		end;
go

create procedure [General].[GetProfileInfoByName]
(
	@profileName varchar(20),
	@platformId int,
	@regionId int
)
as

set nocount on;
set transaction isolation level read committed;

select
	ProfileGuid,
	UserName,
	RegionId,
	PlatformId
from General.UserProfile
where UserName = @profileName
	and RegionId = @regionId
	and PlatformId = @platformId;