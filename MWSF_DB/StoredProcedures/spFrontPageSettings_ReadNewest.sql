CREATE PROCEDURE [dbo].[spFrontPageSettings_ReadNewest]
AS
BEGIN
	SELECT top 1 [Id], [Created], [Modified], [Author], [ShowLogo], [HtmlContent], [ShowCountdown], [CountdownTitle], [CountdownUntil], [ShowAlert],[AlertId]
	FROM dbo.FrontPageSettings
	ORDER BY Id DESC;
END
GO