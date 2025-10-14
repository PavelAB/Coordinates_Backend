CREATE TABLE [dbo].[MM_SurfaceType]
(
	[IdSurface] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[SurfaceType] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_SurfaceType] PRIMARY KEY ([IdSurface]),
	CONSTRAINT [UQ_SurfaceType] UNIQUE ([SurfaceType])
)
