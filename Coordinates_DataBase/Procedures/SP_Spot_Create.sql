CREATE PROCEDURE [dbo].[SP_Spot_Create]
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@Name NVARCHAR(50) = DEFAULT,
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		RAISERROR('The UserId for CreatedBy cannot be null.', 16, 1);


	IF @Name IS NULL
    BEGIN
        INSERT INTO [Spot] (Latitude, Longitude, Elevation, CreatedBy)
        VALUES (@Latitude, @Longitude, @Elevation,  @IdUser);
    END
    ELSE
    BEGIN
        INSERT INTO [Spot] (Latitude, Longitude, Elevation, [Name], CreatedBy)
        VALUES (@Latitude, @Longitude, @Elevation, @Name, @IdUser);
    END
END
GO