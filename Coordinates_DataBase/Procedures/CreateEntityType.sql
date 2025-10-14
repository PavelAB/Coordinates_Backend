CREATE PROCEDURE [dbo].[CreateEntityType]
	@Name NVARCHAR(50)
AS
BEGIN
	INSERT INTO [MM_EntityType] ([Name]) VALUES (@Name);
END
