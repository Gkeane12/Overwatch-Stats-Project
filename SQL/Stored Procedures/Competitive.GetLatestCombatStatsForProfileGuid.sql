/*
Competitive.GetLatestCombatStatsForProfileGuid.sql
*/

if(exists(
select *
from sys.sysobjects
where id = object_id(N'[Competitive].[GetLatestCombatStatsForProfileGuid]')
	and objectproperty(id, N'IsProcedure') =1))
	begin
		drop procedure [Competitive].[GetLatestCombatStatsForProfileGuid];
	end;
go

create procedure [Competitive].[GetLatestCombatStatsForProfileGuid]
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
	SR,
	EnvironmentalKills
from Competitive.OverallCombat
where ProfileGuid = @profileGuid
	order by RecordDate desc;