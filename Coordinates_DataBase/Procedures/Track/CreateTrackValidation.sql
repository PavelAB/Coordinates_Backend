CREATE PROCEDURE [dbo].[CreateTrackValidation]
	@IdTrack UNIQUEIDENTIFIER = NULL,
	@IdUser UNIQUEIDENTIFIER = NULL	
AS
BEGIN

	IF @IdTrack IS NULL
		SELECT TOP 1 @IdTrack = IdTrack FROM [Track];
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];
	

	INSERT INTO [MM_TrackValidation] (IdTrack, IdValidator) VALUES (@IdTrack, @IdUser)
END