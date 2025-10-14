CREATE PROCEDURE [dbo].[CreateCommentTrack]
	@IdTrack UNIQUEIDENTIFIER = NULL,
	@IdComment UNIQUEIDENTIFIER = NULL	
AS
BEGIN
	if(@IdTrack IS NULL)
		SELECT TOP 1 @IdTrack = [IdTrack] FROM [Track];
	if(@IdComment IS NULL)
		SELECT TOP 1 @IdComment = IdComment FROM [Comment];

	INSERT INTO MM_Comment_Track (IdTrack, IdComment) VALUES (@IdTrack, @IdComment);
END