CREATE PROCEDURE [dbo].[CreateSurfaceType]
	@SurfaceType NVARCHAR(50)
AS
BEGIN
	INSERT INTO [Surface] ([SurfaceType]) VALUES (@SurfaceType);
END
