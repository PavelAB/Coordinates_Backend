CREATE FUNCTION [dbo].[SF_HashPassword]
(
	@userPassword NVARCHAR(100),
	@salt UNIQUEIDENTIFIER
)
RETURNS VARBINARY(32)
AS
BEGIN
	DECLARE @saltedPassword NVARCHAR(200)
	SET @saltedPassword = CONCAT(@userPassword, @salt)

	RETURN HASHBYTES('SHA2_256', @saltedPassword)
END
