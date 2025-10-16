CREATE TABLE [dbo].[MM_Spot_EntityType]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL,
	[IdEntityType] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_MM_Spot_EntityType] PRIMARY KEY ([IdEntityType],[IdSpot]),
	CONSTRAINT [FK_SpotEntityType_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]),
	CONSTRAINT [FK_SpotEntityType_EntityType] FOREIGN KEY ([IdEntityType]) REFERENCES [EntityType]([IdEntityType])
)
