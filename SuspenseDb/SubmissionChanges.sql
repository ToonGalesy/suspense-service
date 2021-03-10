CREATE TABLE [dbo].[SubmissionChanges]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Operation] NCHAR(10) NOT NULL, 
    [Path] NVARCHAR(MAX) NOT NULL, 
    [SubmissionId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_SubmissionChange_Submission] FOREIGN KEY ([SubmissionId]) REFERENCES [Submissions]([Id])
)
