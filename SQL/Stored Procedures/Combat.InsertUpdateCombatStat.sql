/*
Combat.InsertUpdateCombatStat.sql
*/

if(exists(
	select * 
	from sys.sysobjects
	where id = object_id(N'[Combat].[InsertUpdateCombatStat]')
		and objectproperty(id, N'IsProcedure')=1))
		begin
			drop procedure [Combat].[InsertUpdateCombatStat];
		end;
go

create procedure [Combat].[InsertUpdateCombatStat]
(
	@profileGuid uniqueidentifier,
	@meleeFinalBlows int,
	@objectiveKills int,
	@soloKills int,
	@finalBlows int,
	@damageDone bigint,
	@eliminations int,
	@multiKills int,
	@environmentalKills int
)

as 
set nocount on;
set transaction isolation level read committed;

declare @currentDate date = getdate();

if(exists(
	select * from Combat.Competitive
	where ProfileGuid = @profileGuid
		and RecordDate = @currentDate))
begin
	update Combat.Competitive
	set 
		MeleeFinalBlows = @meleeFinalBlows,
		ObjectiveKills = @objectiveKills,
		SoloKills = @soloKills,
		FinalBlows = @finalBlows,
		DamageDone = @damageDone,
		Eliminations = @eliminations,
		MultiKills = @multiKills,
		EnvironmentalKills = @environmentalKills,
		RecordDate = @currentDate
	where ProfileGuid = @profileGuid
		and RecordDate = @currentDate;
end
else
begin
	insert into Combat.Competitive
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
		@currentDate
	);
end