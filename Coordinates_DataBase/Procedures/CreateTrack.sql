CREATE PROCEDURE [dbo].[CreateTrack]
	@Distance DECIMAL(8,2),
	@Elevation DECIMAL(8,2),
	@IdUser UNIQUEIDENTIFIER = NULL
	
AS
BEGIN
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = IdUser FROM [User];


	INSERT INTO [Track] (Distance, Elevation, PolyLine, CreatedBy) VALUES 
	(
		@Distance,
		@Elevation,
		'PolyLine not implemented yet',
		@IdUser
	)
END
GO
