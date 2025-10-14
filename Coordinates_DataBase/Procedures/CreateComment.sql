CREATE PROCEDURE [dbo].[CreateComment]
	@Body NVARCHAR(MAX),
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF(@IdUser IS NULL)
		SELECT TOP 1 @IdUser = IdUser FROM [User];

	INSERT INTO Comment (Body, CreatedBy) VALUES (@Body, @IdUser);
END