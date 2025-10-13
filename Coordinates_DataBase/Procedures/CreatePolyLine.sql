CREATE PROCEDURE [dbo].[CreatePolyLine]
	@IdSpot1 UNIQUEIDENTIFIER = NULL,
	@IdSpot2 UNIQUEIDENTIFIER = NULL,
	@IdTrack UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdSpot1 IS NULL
		SELECT TOP 1 @IdSpot1 = IdSpot FROM [Spot];
	IF @IdSpot2 IS NULL
		SELECT @IdSpot2 = IdSpot FROM [Spot] WHERE Longitude = 80;
	IF @IdTrack IS NULL
		SELECT TOP 1 @IdTrack = IdTrack FROM [Track];

	INSERT INTO [MM_PolyLine] ([IdSpot], [IdTrack], [Order]) VALUES 
		(@IdSpot1, @IdTrack, 1);
	INSERT INTO [MM_PolyLine] ([IdSpot], [IdTrack], [Order]) VALUES 
		(@IdSpot2, @IdTrack, 2);
END
GO
