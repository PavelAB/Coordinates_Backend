CREATE PROCEDURE [dbo].[CreateRatingTrack]
	@IdTrack UNIQUEIDENTIFIER = NULL,
	@IdRating UNIQUEIDENTIFIER = NULL	
AS
BEGIN
	if(@IdTrack IS NULL)
		SELECT TOP 1 @IdTrack = [IdTrack] FROM [Track];
	if(@IdRating IS NULL)
		SELECT TOP 1 @IdRating = [IdRating] FROM [Rating];

	INSERT INTO MM_Rating_Track (IdTrack, IdRating) VALUES (@IdTrack, @IdRating);
END
