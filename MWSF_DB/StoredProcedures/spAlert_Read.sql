CREATE PROCEDURE [dbo].[spAlert_Read]
	@Id bigint 
AS
BEGIN
	SELECT TOP 1 [Id], [Created], [Modified], [Name], [HtmlContent], [Severity], [Active]
	FROM Alerts
	WHERE Id = @Id
END
GO