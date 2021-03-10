CREATE TABLE [dbo].[SubmissionProperties]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Property] NVARCHAR(50) NOT NULL, 
    [PreviousValue] NVARCHAR(50) NOT NULL, 
    [NewValue] NVARCHAR(50) NOT NULL, 
    [SubmissionChangeId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_SubmissionProperty_SubmissionChange] FOREIGN KEY ([SubmissionChangeId]) REFERENCES [SubmissionChanges]([Id])
)
