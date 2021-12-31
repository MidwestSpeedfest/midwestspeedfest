CREATE TABLE [dbo].[FrontPageSettings]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Created] DateTime2 CONSTRAINT DF_FrontPageSettings_Created DEFAULT (SYSDATETIME()),
    [Modified] Datetime2,
    [Author] NVARCHAR(50),
    [ShowLogo] BIT NOT NULL DEFAULT 0, 
    [HtmlContent] NVARCHAR(MAX) NULL, 
    [ShowCountdown] BIT NOT NULL DEFAULT 0, 
    [CountdownTitle] NVARCHAR(MAX) NULL, 
    [CountdownUntil] DATETIME2 NULL, 
    [ShowAlert] BIT NOT NULL DEFAULT 0, 
    [AlertId] BIGINT NULL, 
    CONSTRAINT [FK_FrontPageSettings_ToAlerts] FOREIGN KEY (AlertId) REFERENCES Alerts([Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_UpdateModified_FrontPageSettings]
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
