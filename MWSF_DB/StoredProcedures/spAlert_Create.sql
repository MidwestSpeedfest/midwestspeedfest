CREATE PROCEDURE [dbo].[spAlert_Create]
	@Name NVARCHAR(50),
	@HtmlContent NVARCHAR(MAX),
	@Severity INTEGER,
	@Active BIT
AS
BEGIN
	set nocount on
	insert into dbo.Alerts(Name,HtmlContent,Severity, Active)
	values(@Name,@HtmlContent,@Severity, @Active)
END
GO