CREATE PROCEDURE [dbo].[spFrontPageSettings_Create]
	@Author NVARCHAR(50),

	@ShowLogo bit,
    @Headline NVARCHAR(MAX),
	@Details NVARCHAR(MAX),
	
	@ShowCountdown bit,
	@CountdownTitle NVARCHAR(MAX),
	@CountdownUntil Datetime2
AS
BEGIN
	set nocount on
	insert into dbo.FrontPageSettings(Author, ShowLogo, Headline, Details, ShowCountdown, CountdownTitle, CountdownUntil)
	values(@Author, @ShowLogo, @Headline, @Details, @ShowCountdown, @CountdownTitle, @CountdownUntil)

END
