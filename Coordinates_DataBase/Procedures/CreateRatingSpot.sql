CREATE PROCEDURE [dbo].[CreateRatingSpot]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@IdRating UNIQUEIDENTIFIER = NULL	
AS
BEGIN
	if(@IdSpot IS NULL)
		SELECT TOP 1 @IdSpot = [IdSpot] FROM [SPOT];
	if(@IdRating IS NULL)
		SELECT TOP 1 @IdRating = [IdRating] FROM [Rating];

	INSERT INTO MM_Rating_Spot (IdSpot, IdRating) VALUES (@IdSpot, @IdRating);
END