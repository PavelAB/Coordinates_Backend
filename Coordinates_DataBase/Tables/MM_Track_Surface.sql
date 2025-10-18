CREATE TABLE [dbo].[MM_Track_Surface]
(
	[IdSurface] UNIQUEIDENTIFIER NOT NULL,
	[IdTrack] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_MM_Track_Surface] PRIMARY KEY ([IdSurface], [IdTrack]),
	CONSTRAINT [FK_TrackSurface_Spot] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_TrackSurface_Surface] FOREIGN KEY ([IdSurface]) REFERENCES [Surface]([IdSurface])
)
