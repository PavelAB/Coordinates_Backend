CREATE PROCEDURE [dbo].[CreateTrack]
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = IdUser FROM [User];

	INSERT INTO [Track] (Distance, Elevation, PolyLine, CreatedBy) VALUES 
	(
		100.56 ,
		100.56 ,
		'PolyLine not implemented yet',
		@IdUser
	)
END
GO
