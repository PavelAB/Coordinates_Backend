CREATE PROCEDURE [dbo].[SP_User_Create]
	@nickName NVARCHAR(50),
	@email NVARCHAR(500),
	@login NVARCHAR(100),
	@userPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @passwordSalt UNIQUEIDENTIFIER = NEWID()


	INSERT INTO [User] ([Email], [NickName], [Login], [Password], [Salt])
	VALUES (@email, @nickName, @login, [dbo].[SF_HashPassword](@userPassword, @passwordSalt), @passwordSalt )

END