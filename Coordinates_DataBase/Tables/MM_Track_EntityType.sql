CREATE TABLE [dbo].[MM_Track_EntityType]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL,
	[IdEntityType] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_MM_Track_EntityType] PRIMARY KEY ([IdEntityType],[IdTrack]),
	CONSTRAINT [FK_TrackEntityType_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_TrackEntityType_EntityType] FOREIGN KEY ([IdEntityType]) REFERENCES [EntityType]([IdEntityType])
)
