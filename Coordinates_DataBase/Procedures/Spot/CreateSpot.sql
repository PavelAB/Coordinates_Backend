CREATE PROCEDURE [dbo].[CreateSpot]
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];

	INSERT INTO [Spot] (Latitude, Longitude, Elevation,  CreatedBy) VALUES 
	(
		@Latitude,
		@Longitude,
		@Elevation,
		@IdUser
	)
END
GO
