/* 
OverwatchStatsPatch002.sql
Create Combat table in General Schema
*/
use Overwatch
if(not exists(
	select * 
	from information_schema.tables
	where table_schema = 'General'
	and table_name = 'OverallCombatStats'))
	begin
		create table General.OverallCombatStats
		(
			ProfileGuid uniqueidentifier not null,
			MeleeFinalBlows int not null default 0,
			SoloKills int not null default 0,
			ObjectiveKills int not null default 0,
			FinalBlows int not null default 0,
			DamageDone bigint not null default 0,
			Eliminations int not null default 0,
			EnvironmentalKills int not null default 0,
			MultiKills int not null default 0,
			RecordDate date not null default getdate(),
			
			constraint PK_General_OverallCombatStats_ProfileGuid_RecordDate primary key(ProfileGuid, RecordDate),
			constraint FK_General_OverallCombatStats_General_UserProfile_ProfileGuid foreign key (ProfileGuid) references General.UserProfile(ProfileGuid)
		);
	end