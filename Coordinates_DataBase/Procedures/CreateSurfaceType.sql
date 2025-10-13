CREATE PROCEDURE [dbo].[CreateSurfaceType]
	@SurfaceType NVARCHAR(50)
AS
BEGIN
	INSERT INTO [MM_SurfaceType] ([SurfaceType]) VALUES (@SurfaceType);
END
