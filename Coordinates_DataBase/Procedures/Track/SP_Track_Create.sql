CREATE PROCEDURE [dbo].[SP_Track_Create]
	@Distance DECIMAL(8,2),
	@Ascent DECIMAL(8,2),
	@Descent DECIMAL(8,2),
	@Name NVARCHAR(50) = DEFAULT,
	@IsPrivate BIT = 0,
	@PolyLine NVARCHAR(MAX),
	@CreatedBy UNIQUEIDENTIFIER,
    @Surface UNIQUEIDENTIFIER = NULL,
    @EntityType UNIQUEIDENTIFIER = NULL

AS
BEGIN

    BEGIN TRANSACTION
        BEGIN TRY
            IF @Surface IS NULL
                SELECT @Surface = IdSurface FROM Surface WHERE SurfaceType = 'No Information'
            IF @EntityType IS NULL
                SELECT @EntityType = IdEntityType FROM EntityType WHERE [Name] = 'No Information'

	        IF @CreatedBy IS NULL
		        RAISERROR('The UserId for CreatedBy cannot be null.', 16, 1);
            IF NOT EXISTS (SELECT 1 FROM [Surface] WHERE IdSurface = @Surface)
                RAISERROR('Invalid Surface ID.', 16, 1);
            IF NOT EXISTS (SELECT 1 FROM [EntityType] WHERE IdEntityType = @EntityType)
                RAISERROR('Invalid EntityType ID.', 16, 1);

            -- ====

            DECLARE @IdTrack UNIQUEIDENTIFIER;
            DECLARE @OutPut TABLE ( IdTrack UNIQUEIDENTIFIER )
            
	        IF @Name IS NULL
                BEGIN
                    INSERT INTO [Track] (Distance, Ascent, Descent, IsPrivate, PolyLine, CreatedBy)
                    OUTPUT INSERTED.IdTrack INTO @OutPut 
                    VALUES (@Distance, @Ascent, @Descent, @IsPrivate, @PolyLine, @CreatedBy);
                END
            ELSE
                BEGIN
                    INSERT INTO [Track] (Distance, Ascent, Descent, IsPrivate, PolyLine, CreatedBy, [Name])
                    OUTPUT INSERTED.IdTrack INTO @OutPut 
                    VALUES (@Distance, @Ascent, @Descent, @IsPrivate, @PolyLine, @CreatedBy, @Name);
                END       

            SELECT @IdTrack = IdTrack From @OutPut;
                
            -- ====
            
            INSERT INTO [MM_Track_Surface] (IdTrack, IdSurface) VALUES (@IdTrack, @Surface)
            
            -- ====
                        
            INSERT INTO [MM_Track_EntityType] (IdTrack, IdEntityType) VALUES (@IdTrack, @EntityType)

            SELECT @IdTrack;
                                    
            COMMIT
        END TRY
    BEGIN CATCH
        ROLLBACK;
		THROW;       
    END CATCH
END
GO