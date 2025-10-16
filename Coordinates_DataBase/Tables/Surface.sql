﻿CREATE TABLE [dbo].[Surface]
(
	[IdSurface] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[SurfaceType] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Surface] PRIMARY KEY ([IdSurface]),
	CONSTRAINT [UQ_Surface] UNIQUE ([SurfaceType])
)
