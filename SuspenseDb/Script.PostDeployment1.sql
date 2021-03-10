/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into dbo.SubmissionStatus ([Id], [Description])
select NEWID(), N'Submitted'
where not exists (select 1 from dbo.SubmissionStatus where [Description] = 'Submitted')

insert into dbo.SubmissionStatus ([Id], [Description])
select NEWID(), N'Pending Review'
where not exists (select 1 from dbo.SubmissionStatus where [Description] = 'Pending Review')

insert into dbo.SubmissionStatus ([Id], [Description])
select NEWID(), N'Actioned'
where not exists (select 1 from dbo.SubmissionStatus where [Description] = 'Actioned')

insert into dbo.SubmissionStatus ([Id], [Description])
select NEWID(), N'Deleted'
where not exists (select 1 from dbo.SubmissionStatus where [Description] = 'Deleted')