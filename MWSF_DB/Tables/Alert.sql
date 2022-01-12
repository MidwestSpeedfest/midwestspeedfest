CREATE TABLE [dbo].[Alerts]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Created] DATETIME NULL DEFAULT (SYSDATETIME()), 
    [Modified] DATETIME NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [HtmlContent] NVARCHAR(MAX) NOT NULL, 
    [Severity] INT NOT NULL, 
    [Active] BIT NULL DEFAULT 1 
)

Go

CREATE TRIGGER [dbo].[Trigger_UpdateModified_Alert]
    ON [dbo].[Alerts]
    FOR INSERT, UPDATE
    AS
    BEGIN
        UPDATE dbo.Alerts
        SET Modified = SYSDATETIME()
        FROM Inserted i
        WHERE dbo.Alerts.Id = i.Id
    END
GO
