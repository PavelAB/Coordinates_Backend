CREATE PROCEDURE [dbo].[CreateLike]
	@IdComment UNIQUEIDENTIFIER = NULL,
	@IdUser UNIQUEIDENTIFIER = NULL
AS
BEGIN
	IF @IdComment IS NULL
		SELECT TOP 1 @IdComment = [IdComment] FROM [Comment];
	IF @IdUser IS NULL
		SELECT TOP 1 @IdUser = [IdUser] FROM [User];


	INSERT INTO [MM_Liked] (IdComment, IdUser) VALUES (@IdComment, @IdUser);

END