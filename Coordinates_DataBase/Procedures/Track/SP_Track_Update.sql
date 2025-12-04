CREATE PROCEDURE [dbo].[SP_Track_Update]
	@IdTrack UNIQUEIDENTIFIER,
	@UpdatedBy UNIQUEIDENTIFIER,
	@Distance DECIMAL(8,2),
	@Ascent DECIMAL(8,2),
	@Descent DECIMAL(8,2),
	@Name NVARCHAR(50),
	@IsPrivate BIT = 0,
	@PolyLine NVARCHAR(MAX)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			IF NOT EXISTS (SELECT 1 FROM [Track] WHERE IdTrack = @IdTrack)
                RAISERROR('Invalid Track ID.', 16, 1);

			IF NOT EXISTS (SELECT 1 FROM [User] WHERE IdUser = @UpdatedBy)
                RAISERROR('Invalid UpdateBy ID.', 16, 1);

			UPDATE Track
			SET
				Distance = @Distance,
				Ascent = @Ascent,
				Descent = @Descent,
				[Name] = @Name,
				IsPrivate = @IsPrivate,
				PolyLine = @PolyLine,
				UpdatedBy = @UpdatedBy,
				UpdatedAt = GETDATE()
			WHERE IdTrack = @IdTrack

			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
END
