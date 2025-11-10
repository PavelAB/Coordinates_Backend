CREATE PROCEDURE [dbo].[SP_User_GetById]
	@searchId UNIQUEIDENTIFIER 
AS
BEGIN
	IF @searchId IS NULL
		RAISERROR('The UserId for searchId cannot be null.', 16, 1);

	SELECT [IdUser], [FirstName], [LastName], [NickName], [Login], [Email], [Avatar], [CreatedAt], [UpdatedAt] 
	FROM [User] 
	WHERE [IdUser] = @searchId
END 
GO
