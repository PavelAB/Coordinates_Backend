CREATE PROCEDURE [dbo].[CreateTrack]
	@Distance DECIMAL(8,2),
	@Elevation DECIMAL(8,2),
	@IdUser UNIQUEIDENTIFIER = NULL,
	@IdEntityType UNIQUEIDENTIFIER = NULL,
	@IdSurfaceType UNIQUEIDENTIFIER = NULL
	
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = IdUser FROM [User];
	IF @IdEntityType IS NULL
		SELECT @IdEntityType = [IdEntityType] FROM [MM_EntityType] WHERE Name = 'No Information';
	IF @IdSurfaceType IS NULL
		SELECT @IdSurfaceType = [IdSurface] FROM [MM_SurfaceType] WHERE [SurfaceType] = 'No Information';


	INSERT INTO [Track] (Distance, Elevation, PolyLine, IdEntityType, IdSurfaceType,CreatedBy) VALUES 
	(
		@Distance,
		@Elevation,
		'PolyLine not implemented yet',
		@IdEntityType,
		@IdSurfaceType,
		@IdUser
	)
END
GO
