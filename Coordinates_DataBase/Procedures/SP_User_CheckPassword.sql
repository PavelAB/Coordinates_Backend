CREATE PROCEDURE [dbo].[SP_User_CheckPassword]
	@login NVARCHAR(100),
	@password NVARCHAR(100)
AS
BEGIN
	SELECT [IdUser], [FirstName], [LastName], [NickName], [Login], [Email], [Avatar], [CreatedAt], [UpdatedAt] 
	FROM [User] 
	WHERE 
		[login] = @login AND
		[Password] = [dbo].[SF_HashPassword](@password, [Salt])		
END
GO
