/* 
CleanUp.DeleteUser.sql --- 
stored procedure for deleting information regarding a specific user using uniqueidentifier(GUID)
*/

if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[CleanUp].[DeleteUser]')
		and objectproperty(id, N'IsProcedure')=1))
		begin
			drop procedure [CleanUp].[DeleteUser];
		end
go

create procedure [CleanUp].[DeleteUser]
(
	@profileGuid uniqueidentifier
)
as

set nocount on;
set transaction isolation level read committed;


delete from General.OverallCombatStats where ProfileGuid = @profileGuid
delete from General.UserProfile where ProfileGuid = @profileGuid;

go


