/* 
CreateCleanUpSchema.sql ---- creates Clean up schema
*/
use Overwatch
if schema_id('CleanUp') is null
	execute('create schema CleanUp');