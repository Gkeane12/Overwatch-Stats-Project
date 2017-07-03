/* 
OverwatchStatsPatch001.sql
Create General Schema
Create following tables:
General.Region for storing the different Regions,
General.Platform table to store the different type of platform
General.UserProfile table responsible for storing information regarding the specific profile,  
*/
-----------Create General Schema-----------
use Overwatch;
if schema_id('General') is null
	execute('create schema General');

-----------Create Region table for General schema and intial data-----------
if(not exists(
	select *
	from information_schema.tables
	where table_schema = 'General'
	and table_name = 'Region'))
	begin 
		create table General.Region
		(
			RegionId int identity(0,1) primary key,
			RegionAbv varchar(2) not null,
			constraint UQ_General_Region_RegionAbv unique(RegionAbv)
		);

		declare @euRegion varchar(2) = 'eu';
		declare @usRegion varchar(2) = 'us';
		declare @asiaRegion varchar(2) = 'kr';
		declare @notApplicable varchar(2) = '--'

		insert into General.Region
			(RegionAbv)
		values
		(@notApplicable),
			(@euRegion),
			(@usRegion),
			(@asiaRegion);


	end

-----------Create Platform table for General schema and intial data-----------
if(not exists(
	select *
	from information_schema.tables
	where table_schema = 'General'
	and table_name = 'Platform'))
	begin
		create table [General].[Platform]
		(
			PlatformId int identity(1,1) primary key,
			PlatformAbv varchar(5) not null,
			constraint UQ_General_Platform_PlatformAbv unique (PlatformAbv)
		);

		declare @pcPlatform varchar(5) = 'pc';
		declare @psPlatform varchar(5) = 'psn';
		declare @xblPlatform varchar(5) = 'xbl';
		declare @noPlatform varchar(5) = 'NONE'

		insert into [General].[Platform]
			(PlatformAbv)
		values
			(@noPlatform),
			(@pcPlatform),
			(@psPlatform),
			(@xblPlatform);
	end


-----------Create User Profile table for general schema-----------
if(not exists(
	select *
	from information_schema.tables
	where table_schema = 'General'
	and table_name = 'UserProfile'))
	begin
		create table General.UserProfile
		(
			ProfileGuid uniqueidentifier primary key,
			UserName varchar(20) not null,
			RegionId int not null,
			PlatformId int not null,
			constraint FK_General_UserProfile_General_Region_RegionId foreign key (RegionId) references General.Region(RegionId),
			constraint FK_General_UserProfile_General_Platform_PlatformId foreign key (PlatformId) references [General].[Platform](PlatformId)
		);
	end