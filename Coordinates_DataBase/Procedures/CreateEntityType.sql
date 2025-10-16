CREATE PROCEDURE [dbo].[CreateEntityType]
	@Name NVARCHAR(50)
AS
BEGIN
	INSERT INTO [EntityType] ([Name]) VALUES (@Name);
END
