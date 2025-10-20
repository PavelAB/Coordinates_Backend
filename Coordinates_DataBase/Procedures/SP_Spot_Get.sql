CREATE PROCEDURE [dbo].[SP_Spot_Get]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@Latitude DECIMAL(9,6) = NULL,
	@Longitude DECIMAL(9,6) = NULL,
	@Name NVARCHAR(50) = NULL,
	@CreatedBy UNIQUEIDENTIFIER = NULL,
	@IsPrivate BIT = NULL
AS
BEGIN
	SELECT IdSpot, Latitude, Longitude, Elevation, [Name], IsPrivate, CreatedAt, CreatedBy 
	FROM Spot
	WHERE (@IdSpot IS NULL OR IdSpot = @IdSpot)
		AND (@Latitude IS NULL OR Latitude = @Latitude)
		AND (@Longitude IS NULL OR Longitude = @Longitude)
		AND (@Name IS NULL OR [Name] = @Name)
		AND (@CreatedBy IS NULL OR CreatedBy = @CreatedBy)
		AND (@IsPrivate IS NULL OR IsPrivate = @IsPrivate)
END
