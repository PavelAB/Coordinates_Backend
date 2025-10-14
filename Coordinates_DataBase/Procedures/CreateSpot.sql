CREATE PROCEDURE [dbo].[CreateSpot]
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@IdUser UNIQUEIDENTIFIER = NULL,
	@IdEntityType UNIQUEIDENTIFIER = NULL,
	@IdSurfaceType UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];
	IF @IdEntityType IS NULL
		SELECT @IdEntityType = [IdEntityType] FROM [MM_EntityType] WHERE Name = 'No Information';
	IF @IdSurfaceType IS NULL
		SELECT @IdSurfaceType = [IdSurface] FROM [MM_SurfaceType] WHERE [SurfaceType] = 'No Information';

	INSERT INTO [Spot] (Latitude, Longitude, Elevation, IdEntityType, IdSurfaceType, CreatedBy) VALUES 
	(
		@Latitude,
		@Longitude,
		@Elevation,
		@IdEntityType,
		@IdSurfaceType,
		@IdUser
	)
END
GO
