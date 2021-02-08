CREATE PROCEDURE [dbo].[spFrontPageSettings_Create]
	@Author NVARCHAR(50),

	@ShowLogo bit,
	@HtmlContent NVARCHAR(MAX),
	
	@ShowCountdown bit,
	@CountdownTitle NVARCHAR(MAX),
	@CountdownUntil Datetime2
AS
BEGIN
	set nocount on
	insert into dbo.FrontPageSettings(Author, ShowLogo, HtmlContent, ShowCountdown, CountdownTitle, CountdownUntil)
	values(@Author, @ShowLogo, @HtmlContent, @ShowCountdown, @CountdownTitle, @CountdownUntil)

END
