﻿CREATE PROCEDURE [dbo].[spAlert_Update]
	@Id BIGINT,
	@Name NVARCHAR(50),
	@HtmlContent NVARCHAR(MAX),
	@Severity NVARCHAR(50),
	@Active BIT
AS
BEGIN
	UPDATE Alerts 
		SET Name = @Name, HtmlContent = @HtmlContent, Severity = @Severity, Active = @Active
		Where Id = @Id
END
GO