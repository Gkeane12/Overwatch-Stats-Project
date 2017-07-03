/*
OverwatchStatsPatch005.sql
create Competitive Schema
move all stored procs and tables from Combat Schema
rename Combat.Competitive to Competitive.OverallCombat
rename all constraints to reflect new table and schema changes
to new Competitive Schema
*/
------Create Competitive Schema------
if schema_id('Çompetitive') is null
	execute('create schema Competitive');

go

------Rename table Combat.Competitive------
exec sp_rename '[Combat].[Competitive]', 'OverallCombat'

go

------Move tables and stored procs from Combat schema to Competitive------
alter schema Competitive transfer Combat.OverallCombat;

if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Combat].[GetLatestCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			alter schema Competitive transfer Combat.GetLatestCombatStatsForProfileGuid;
		end;

if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Combat].[GetAllCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			alter schema Competitive transfer Combat.GetAllCombatStatsForProfileGuid;
		end;


if(exists(
	select *
	from sys.sysobjects
	where id = object_id(N'[Combat].[GetAllCombatStatsForProfileGuid]')
		and objectproperty(id, N'IsProcedure') =1))
		begin
			alter schema Competitive transfer Combat.GetAllCombatStatsForProfileGuid;
		end;

go

------rename Constraints------
exec sp_rename N'Competitive.OverallCombat.PK_Combat_Competitive_ProfileGuid_RecordDate', N'PK_Competitive_OverallCombat_ProfileGuid_RecordDate';
exec sp_rename N'Competitive.FK_Combat_Competitive_General_UserProfile_ProfileGuid', N'FK_Competitive_OverallCombat_General_UserProfile_ProfileGuid';