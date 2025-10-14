CREATE PROCEDURE [dbo].[CreateFavoriteSpot]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@IdUser UNIQUEIDENTIFIER = NULL	
AS
BEGIN

	IF @IdSpot IS NULL
		SELECT TOP 1 @IdSpot = IdSpot FROM [Spot];
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];
	

	INSERT INTO [MM_FavoriteSpot] (IdSpot, IdUser) VALUES (@IdSpot, @IdUser)
END