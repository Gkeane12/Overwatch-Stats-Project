/* 
Competitive.GetAllCombatStatsForProfileGuid.sql
*/
if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Competitive].[GetAllCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			drop procedure [Competitive].[GetAllCombatStatsForProfileGuid];
		end;
go

create procedure [Competitive].[GetAllCombatStatsForProfileGuid]
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
	SR,
	EnvironmentalKills
from Competitive.OverallCombat
where ProfileGuid = @profileGuid
	order by RecordDate desc;