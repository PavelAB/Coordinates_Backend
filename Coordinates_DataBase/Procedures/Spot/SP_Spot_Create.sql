CREATE PROCEDURE [dbo].[SP_Spot_Create]
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@Name NVARCHAR(50) = DEFAULT,
	@IdUser UNIQUEIDENTIFIER = NULL,
    @Surface UNIQUEIDENTIFIER = NULL,
    @EntityType UNIQUEIDENTIFIER = NULL
AS
BEGIN
    
    BEGIN TRANSACTION

    DECLARE @IdSpot UNIQUEIDENTIFIER

    BEGIN TRY

            IF @Surface IS NULL
                SELECT @Surface = IdSurface FROM Surface WHERE SurfaceType = 'No Information'
            IF @EntityType IS NULL
                SELECT @EntityType = IdEntityType FROM EntityType WHERE [Name] = 'No Information'

	        IF @IdUser IS NULL
		        RAISERROR('The UserId for CreatedBy cannot be null.', 16, 1);
            IF NOT EXISTS (SELECT 1 FROM [Surface] WHERE IdSurface = @Surface)
                RAISERROR('Invalid Surface ID.', 16, 1);
            IF NOT EXISTS (SELECT 1 FROM [EntityType] WHERE IdEntityType = @EntityType)
                RAISERROR('Invalid EntityType ID.', 16, 1);

            --====

            IF NOT EXISTS (SELECT 1 FROM [Spot] WHERE [Latitude] = @Latitude AND [Longitude] = @Longitude)
                BEGIN
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
            

            -- ====

            SELECT @IdSpot = IdSpot FROM [Spot] WHERE [Latitude] = @Latitude AND [Longitude] = @Longitude

            -- ====

            IF NOT EXISTS (SELECT 1 FROM [MM_Spot_Surface] WHERE IdSpot = @IdSpot AND IdSurface = @Surface)
                BEGIN
                    INSERT INTO [MM_Spot_Surface] (IdSpot, IdSurface) VALUES (@IdSpot, @Surface)
                END

            -- ====

            IF NOT EXISTS (SELECT 1 FROM [MM_Spot_EntityType] WHERE IdSpot = @IdSpot AND IdEntityType = @EntityType)
                BEGIN
                    INSERT INTO [MM_Spot_EntityType] (IdSpot, IdEntityType) VALUES (@IdSpot, @EntityType)
                END
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
		THROW;       
    END CATCH
END
GO