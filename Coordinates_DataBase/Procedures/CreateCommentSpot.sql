CREATE PROCEDURE [dbo].[CreateCommentSpot]
	@IdSpot UNIQUEIDENTIFIER = NULL,
	@IdComment UNIQUEIDENTIFIER = NULL	
AS
BEGIN
	if(@IdSpot IS NULL)
		SELECT TOP 1 @IdSpot = IdSpot FROM [SPOT];
	if(@IdComment IS NULL)
		SELECT TOP 1 @IdComment = IdComment FROM [Comment];

	INSERT INTO MM_Comment_Spot (IdSpot, IdComment) VALUES (@IdSpot, @IdComment);
END