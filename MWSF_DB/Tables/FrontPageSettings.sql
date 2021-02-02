CREATE TABLE [dbo].[FrontPageSettings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Created] DateTime2 CONSTRAINT DF_FrontPageSettings_Created DEFAULT (SYSDATETIME()),
    [Modified] Datetime2,
    [Author] NVARCHAR(50),
    [ShowLogo] BIT NOT NULL, 
    [Headline] NVARCHAR(MAX) NULL, 
    [Details] NVARCHAR(MAX) NULL, 
    [ShowCountdown] BIT NOT NULL, 
    [CountdownTitle] NVARCHAR(MAX) NULL, 
    [CountdownUntil] DATETIME2 NULL
)

GO


CREATE TRIGGER [dbo].[Trigger_UpdateModified]
    ON [dbo].[FrontPageSettings]
    FOR INSERT, UPDATE
    AS
    BEGIN
        UPDATE dbo.FrontPageSettings
        SET Modified = SYSDATETIME()
        FROM Inserted i
        WHERE dbo.FrontPageSettings.Id = i.Id
    END
GO

CREATE INDEX [IX_FrontPageSettings_Id] ON [dbo].[FrontPageSettings] (Id)
