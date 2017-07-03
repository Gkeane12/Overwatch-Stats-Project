/*
OverwatchStatsPatch003.sql
Create Combat Schema
Create Combat.Competitive Table 
*/
use Overwatch
--------Create Combat Schema--------
if schema_id('Combat') is null
	execute('create schema Combat');

--------Create Combat.CompetitiveTable--------
if(not exists(
	select *
	from information_schema.tables
	where table_schema = 'Combat'
	and table_name = 'Competitive'))
	begin
		create table Combat.Competitive
		(
			ProfileGuid uniqueidentifier not null,
			MeleeFinalBlows int not null,
			ObjectiveKills int not null,
			SoloKills int not null,
			FinalBlows int not null,
			DamageDone bigint not null,
			Eliminations int not null,
			MultiKills int not null,
			RecordDate Date not null,
			constraint PK_Combat_Competitive_ProfileGuid_RecordDate primary key (ProfileGuid, RecordDate),
			constraint FK_Combat_Competitive_General_UserProfile_ProfileGuid foreign key (ProfileGuid) references [General].[UserProfile](ProfileGuid)
		);
	end