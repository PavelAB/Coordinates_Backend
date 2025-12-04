CREATE PROCEDURE [dbo].[SP_Spot_Delete]
	@IdSpot UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY

			IF NOT EXISTS (SELECT 1 FROM [Spot] WHERE IdSpot = @IdSpot)
                RAISERROR('Invalid Spot ID.', 16, 1);
				
			IF NOT EXISTS (SELECT 1 FROM [User] WHERE IdUser = @DeletedBy)
                RAISERROR('Invalid DeletedBy ID.', 16, 1);

			UPDATE Spot
			SET
				IsDeleted = 1,
				DeletedBy = @DeletedBy,
				DeletedAt = GETDATE()
			WHERE IdSpot = @IdSpot


			COMMIT
		END TRY
	BEGIN CATCH
		ROLLBACK;

		THROW;
	END CATCH
END
