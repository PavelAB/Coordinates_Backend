CREATE PROCEDURE [dbo].[SP_Spot_Get]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@Latitude DECIMAL(9,6) = NULL,
	@Longitude DECIMAL(9,6) = NULL,
	@Name NVARCHAR(50) = NULL,
	@CreatedBy UNIQUEIDENTIFIER = NULL,
	@IsPrivate BIT = NULL
AS
BEGIN
	SELECT 
		Spot.IdSpot, 
		Latitude, 
		Longitude, 
		Elevation, 
		Spot.[Name], 
		IsPrivate, 
		CreatedAt, 
		CreatedBy, 
		Surface.IdSurface as IdSurface, 
		Surface.SurfaceType as SurfaceType,
		EntityType.IdEntityType as IdEntityType,
		EntityType.Name as EntityName
	FROM Spot JOIN MM_Spot_Surface
		ON Spot.IdSpot = MM_Spot_Surface.IdSpot
		JOIN Surface
		ON MM_Spot_Surface.IdSurface = Surface.IdSurface
		JOIN MM_Spot_EntityType
		ON Spot.IdSpot = MM_Spot_EntityType.IdSpot
		JOIN EntityType
		ON MM_Spot_EntityType.IdEntityType = EntityType.IdEntityType
	WHERE (@IdSpot IS NULL OR Spot.IdSpot = @IdSpot)
		AND (@Latitude IS NULL OR Latitude = @Latitude)
		AND (@Longitude IS NULL OR Longitude = @Longitude)
		AND (@Name IS NULL OR Spot.[Name] = @Name)
		AND (@CreatedBy IS NULL OR CreatedBy = @CreatedBy)
		AND (@IsPrivate IS NULL OR IsPrivate = @IsPrivate)

END
