CREATE PROCEDURE [dbo].[CreateTrack]
	@Distance DECIMAL(8,2),
	@Ascent DECIMAL(8,2),
	@Descent DECIMAL(8,2),
	@IdUser UNIQUEIDENTIFIER = NULL
	
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = IdUser FROM [User];


	INSERT INTO [Track] (Distance, Ascent, Descent, PolyLine, CreatedBy) VALUES 
	(
		@Distance,
		@Ascent,
		@Descent,
		'PolyLine not implemented yet',
		@IdUser
	)
END
GO
