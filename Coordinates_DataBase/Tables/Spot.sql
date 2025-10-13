CREATE TABLE [dbo].[Spot]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	-- CONSTRAINT VALUE BEETWEEN OK 
	[Latitude] DECIMAL(9,6) NOT NULL,
	[Longitude] DECIMAL(9,6) NOT NULL,
	[Elevation] DECIMAL(8,2) NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	[IsPrivate] BIT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	[DeletedAt] DATETIME2 NULL,
	-- FK EntityType manyToOne, constaint default value 'None'
	[IdEntityType] UNIQUEIDENTIFIER NOT NULL,
	-- FK SurfaceType manyToOne, constaint default value 'None'
	[IdSurfaceType] UNIQUEIDENTIFIER NOT NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedBy] UNIQUEIDENTIFIER NOT NULL,
	[DeletedBy] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Spot] PRIMARY KEY ([IdSpot]), 
    CONSTRAINT [FK_Spot_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [User]([IdUser])
)
