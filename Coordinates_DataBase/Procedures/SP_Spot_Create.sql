CREATE PROCEDURE [dbo].[SP_Spot_Create]
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@Name NVARCHAR(50) = DEFAULT,
	@IdUser UNIQUEIDENTIFIER = NULL,
	@IdEntityType UNIQUEIDENTIFIER = NULL,
	@IdSurfaceType UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		RAISERROR('The UserId for CreatedBy cannot be null.', 16, 1);
	IF @IdEntityType IS NULL
		RAISERROR('The IdEntityType for EntityType cannot be null.', 16, 1);
	IF @IdSurfaceType IS NULL
		RAISERROR('The IdSurfaceType for SurfaceType cannot be null.', 16, 1);


	IF @Name IS NULL
    BEGIN
        INSERT INTO [Spot] (Latitude, Longitude, Elevation, IdEntityType, IdSurfaceType, CreatedBy)
        VALUES (@Latitude, @Longitude, @Elevation, @IdEntityType, @IdSurfaceType, @IdUser);
    END
    ELSE
    BEGIN
        INSERT INTO [Spot] (Latitude, Longitude, Elevation, [Name], IdEntityType, IdSurfaceType, CreatedBy)
        VALUES (@Latitude, @Longitude, @Elevation, @Name, @IdEntityType, @IdSurfaceType, @IdUser);
    END
END
GO