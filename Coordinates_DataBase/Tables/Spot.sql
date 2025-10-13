CREATE TABLE [dbo].[Spot]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	-- BEGIN CONSTRAINT VALUE BEETWEEN OK 
	[Latitude] DECIMAL(9,6) NOT NULL,
	[Longitude] DECIMAL(9,6) NOT NULL,
	[Elevation] DECIMAL(8,2) NOT NULL,
	-- END
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	[IsPrivate] BIT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	[DeletedAt] DATETIME2 NULL,
	-- FK EntityType manyToOne, change not null, constaint default value 'None'
	[IdEntityType] UNIQUEIDENTIFIER NULL,
	-- FK SurfaceType manyToOne, change not null, constaint default value 'None'
	[IdSurfaceType] UNIQUEIDENTIFIER NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedBy] UNIQUEIDENTIFIER NULL,
	[DeletedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Spot] PRIMARY KEY ([IdSpot]), 
    CONSTRAINT [FK_Spot_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [User]([IdUser])
)
