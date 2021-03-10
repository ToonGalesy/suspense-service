CREATE TABLE [dbo].[Submissions]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SubmissionType] NVARCHAR(50) NOT NULL, 
    [SubmissionDate] DATETIME2 NOT NULL, 
    [SubmissionStatusId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Submissions_SubmissionStatus] FOREIGN KEY ([SubmissionStatusId]) REFERENCES [SubmissionStatus]([Id])
)
