CREATE TABLE [dbo].[MM_Spot_Surface]
(
	[IdSurface] UNIQUEIDENTIFIER NOT NULL,
	[IdSpot] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_MM_Spot_Surface] PRIMARY KEY ([IdSurface], [IdSpot]),
	CONSTRAINT [FK_SpotSurface_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]),
	CONSTRAINT [FK_SpotSurface_Surface] FOREIGN KEY ([IdSurface]) REFERENCES [Surface]([IdSurface])
)
