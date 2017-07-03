/*
Combat.GetLatestCombatStatsForProfileGuid.sql
*/

if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Combat].[GetLatestCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			drop procedure [Combat].[GetLatestCombatStatsForProfileGuid];
		end;
go

create procedure [Combat].[GetLatestCombatStatsForProfileGuid]
(
	@profileGuid uniqueidentifier
)
as
set nocount on;
set transaction isolation level read committed;

select top 1
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

	select * from Combat.Competitive