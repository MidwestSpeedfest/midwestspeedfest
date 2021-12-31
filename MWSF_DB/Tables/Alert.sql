CREATE TABLE [dbo].[Alerts]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Created] DATETIME NULL DEFAULT (SYSDATETIME()), 
    [Modified] DATETIME NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [HtmlContent] NVARCHAR(MAX) NOT NULL, 
    [Severity] NVARCHAR(50) NOT NULL, 
    [Active] BIT NULL DEFAULT 1 
)

Go

CREATE TRIGGER [dbo].[Trigger_UpdateModified_Alert]
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
