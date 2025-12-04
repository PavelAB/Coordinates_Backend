CREATE PROCEDURE [dbo].[SP_Spot_Get_Light]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@Latitude DECIMAL(9,6) = NULL,
	@Longitude DECIMAL(9,6) = NULL,
	@Name NVARCHAR(50) = NULL,
	@CreatedBy UNIQUEIDENTIFIER = NULL,
	@IsPrivate BIT = 0
AS
BEGIN
	SELECT 
		Spot.IdSpot, 
		Latitude, 
		Longitude, 
		Elevation
	FROM Spot 
	WHERE (@IdSpot IS NULL OR Spot.IdSpot = @IdSpot)
		AND (@Latitude IS NULL OR Latitude = @Latitude)
		AND (@Longitude IS NULL OR Longitude = @Longitude)
		AND (@Name IS NULL OR Spot.[Name] = @Name)
		AND (@CreatedBy IS NULL OR CreatedBy = @CreatedBy)
		AND (@IsPrivate IS NULL OR IsPrivate = @IsPrivate)
END
