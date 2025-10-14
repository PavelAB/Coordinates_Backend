CREATE PROCEDURE [dbo].[CreateFavoriteTrack]
	@IdTrack UNIQUEIDENTIFIER = NULL,
	@IdUser UNIQUEIDENTIFIER = NULL	
AS
BEGIN

	IF @IdTrack IS NULL
		SELECT TOP 1 @IdTrack = [IdTrack] FROM [Track];
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];
	

	INSERT INTO [MM_FavoriteTrack] (IdTrack, IdUser) VALUES (@IdTrack, @IdUser)
END
