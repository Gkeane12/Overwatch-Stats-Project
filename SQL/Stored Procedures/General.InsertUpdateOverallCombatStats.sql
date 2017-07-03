/* 
General.InsertUpdateOverallCombatStats.sql
*/
if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[General].[InsertUpdateOverallCombatStats]')
		and objectproperty(id, N'IsProcedure')=1))
		begin
			drop procedure [General].[InsertUpdateOverallCombatStats];
		end;
go

create procedure [General].[InsertUpdateOverallCombatStats]
(
	@profileGuid uniqueidentifier,
	@meleeFinalBlows int = 0,
	@soloKills int = 0,
	@objectiveKills int = 0,
	@finalBlows int = 0,
	@damageDone bigint = 0,
	@eliminations int = 0,
	@environmentalKills int = 0,
	@multiKills int = 0
)
as

set nocount on;
set transaction isolation level read committed;
declare @recordDate date = getdate();

if(exists(
	select * 
	from General.OverallCombatStats
	where ProfileGuid = @profileGuid
	and RecordDate = @recordDate))
begin
	update General.OverallCombatStats
	set 
		MeleeFinalBlows = @meleeFinalBlows,
		SoloKills = @soloKills,
		ObjectiveKills = @objectiveKills,
		FinalBlows = @finalBlows,
		DamageDone = @damageDone,
		Eliminations = @eliminations,
		EnvironmentalKills = @environmentalKills,
		MultiKills = @multiKills
	where ProfileGuid = @profileGuid
		and RecordDate = @recordDate;
	end
else
begin
	insert into General.OverallCombatStats
	(
		ProfileGuid, 
		MeleeFinalBlows, 
		SoloKills, 
		ObjectiveKills, 
		FinalBlows, 
		DamageDone,
		Eliminations,
		EnvironmentalKills,
		MultiKills
	)
	values
	(
		@profileGuid,
		@meleeFinalBlows,
		@soloKills,
		@objectiveKills,
		@finalBlows,
		@damageDone,
		@eliminations,
		@environmentalKills,
		@multiKills
	);
end
