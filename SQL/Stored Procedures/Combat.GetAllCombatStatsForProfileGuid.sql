/* 
Combat.GetAllCombatStatsForProfileGuid.sql
*/
if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Combat].[GetAllCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			drop procedure [Combat].[GetAllCombatStatsForProfileGuid];
		end;
go

create procedure [Combat].[GetAllCombatStatsForProfileGuid]
(
	@profileGuid uniqueidentifier
)
as
set nocount on set transaction isolation level read committed;

select
	ProfileGuid,
	MeleeFinalBlows,
	ObjectiveKills,
	SoloKills,
	FinalBlows,
	DamageDone,
	Eliminations,
	MultiKills,
	RecordDate,
	EnvironmentalKills
from Combat.Competitive
where ProfileGuid = @profileGuid
	order by RecordDate desc;