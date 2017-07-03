/*
OverwatchStatsPatch003.sql
Adding Environmental Kills to Combat.OverallCombatStats table as it was missed in previous patch
Giving all previous values a value of 0 before adding not null constraint
*/
alter table Combat.Competitive
	add EnvironmentalKills int;
go
-----Giving all current Record in table for environmental kills 0-----
update Combat.Competitive
	set EnvironmentalKills = 0;
go

alter table Combat.Competitive
	alter column EnvironmentalKills int not null;