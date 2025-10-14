CREATE PROCEDURE [dbo].[CreateRating]
	@Score INT,
	@CreatedBy UNIQUEIDENTIFIER = NULL
AS
BEGIN
	
	IF(@CreatedBy IS NULL)
		SELECT TOP 1 @CreatedBy = [IdUser] FROM [User];

	INSERT INTO [Rating] (Score, CreatedBy) VALUES (@Score, @CreatedBy);
END
