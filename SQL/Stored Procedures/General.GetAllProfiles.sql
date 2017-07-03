/* 
	General.GetAllProfiles.sql
*/

if(exists(
	select * 
	from sys.sysobjects
	where id = object_id(N'[General].[GetAllProfiles]')
		and objectproperty(id, N'IsProcedure') = 1))
		begin
			drop procedure [General].[GetAllProfiles];
		end;
go

create procedure General.GetAllProfiles
as
set nocount on;
set transaction isolation level read committed

select
	ProfileGuid,
	UserName,
	RegionId,
	PlatformId
from General.UserProfile;
