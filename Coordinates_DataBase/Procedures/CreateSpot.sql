CREATE PROCEDURE [dbo].[CreateSpot]
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = IdUser FROM [User];

	INSERT INTO [Spot] (Latitude, Longitude, Elevation, CreatedBy) VALUES 
	(
		100.56 ,
		100.56 ,
		100.56 ,
		@IdUser
	)
END
GO
