CREATE PROCEDURE [dbo].[SP_Spot_Update]
	@IdSpot UNIQUEIDENTIFIER,
	@Latitude DECIMAL(9,6),
	@Longitude DECIMAL(9,6),
	@Elevation DECIMAL(8,2),
	@Name NVARCHAR(50),
	@IsPrivate BIT = 0,
	@CreatedBy UNIQUEIDENTIFIER,
	@UpdatedBy UNIQUEIDENTIFIER
AS
BEGIN
	
	BEGIN TRANSACTION
		BEGIN TRY

			IF NOT EXISTS (SELECT 1 FROM [Spot] WHERE IdSpot = @IdSpot)
                RAISERROR('Invalid Spot ID.', 16, 1);

			UPDATE Spot
			SET 
				Latitude = @Latitude,
				Longitude = @Longitude,
				Elevation = @Elevation,
				[Name] = @Name,
				IsPrivate = @IsPrivate,
				CreatedBy = @CreatedBy,
				UpdatedBy = @UpdatedBy,
				UpdatedAt = GETDATE()
			WHERE IdSpot = @IdSpot


		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK;

		THROW;
	END CATCH
END