CREATE PROCEDURE [dbo].[spFrontPageSettings_Create]
	@Author NVARCHAR(50),

	@ShowLogo bit,
	@HtmlContent NVARCHAR(MAX),
	
	@ShowCountdown bit,
	@CountdownTitle NVARCHAR(MAX),
	@CountdownUntil Datetime2,

	@ShowAlert bit,
	@AlertId bigint
AS
BEGIN
	set nocount on
	insert into dbo.FrontPageSettings(Author, ShowLogo, HtmlContent, ShowCountdown, CountdownTitle, CountdownUntil, ShowAlert, AlertId)
	values(@Author, @ShowLogo, @HtmlContent, @ShowCountdown, @CountdownTitle, @CountdownUntil, @ShowAlert, @AlertId)

END
