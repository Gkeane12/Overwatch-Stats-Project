/*
Competitive.InsertUpdateCombatStat.sql
*/

if(exists(
	select * 
	from sys.sysobjects
	where id = object_id(N'[Competitive].[InsertUpdateCombatStat]')
		and objectproperty(id, N'IsProcedure')=1))
		begin
			drop procedure [Competitive].[InsertUpdateCombatStat];
		end;
go

create procedure [Competitive].[InsertUpdateCombatStat]
(
	@profileGuid uniqueidentifier,
	@meleeFinalBlows int,
	@objectiveKills int,
	@soloKills int,
	@finalBlows int,
	@damageDone bigint,
	@eliminations int,
	@multiKills int,
	@environmentalKills int,
	@sr int
)

as 
set nocount on;
set transaction isolation level read committed;

declare @currentDate date = getdate();

if(exists(
	select * from Competitive.OverallCombat
	where ProfileGuid = @profileGuid
		and RecordDate = @currentDate))
begin
	update Competitive.OverallCombat
	set 
		MeleeFinalBlows = @meleeFinalBlows,
		ObjectiveKills = @objectiveKills,
		SoloKills = @soloKills,
		FinalBlows = @finalBlows,
		DamageDone = @damageDone,
		Eliminations = @eliminations,
		MultiKills = @multiKills,
		EnvironmentalKills = @environmentalKills,
		RecordDate = @currentDate,
		SR = @sr
	where ProfileGuid = @profileGuid
		and RecordDate = @currentDate;
end
else
begin
	insert into Competitive.OverallCombat
	(
		ProfileGuid, 
		MeleeFinalBlows, 
		ObjectiveKills, 
		SoloKills, 
		FinalBlows,
		DamageDone,
		Eliminations,
		MultiKills,
		EnvironmentalKills,
		SR,
		RecordDate
	) 
	values
	(
		@profileGuid,
		@meleeFinalBlows,
		@objectiveKills,
		@soloKills,
		@finalBlows,
		@damageDone,
		@eliminations,
		@multiKills,
		@environmentalKills,
		@sr,
		@currentDate
	);
end