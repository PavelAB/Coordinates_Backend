CREATE TABLE [dbo].[Spot]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
	[Latitude] DECIMAL(9,6) NOT NULL,
	[Longitude] DECIMAL(9,6) NOT NULL,
	[Elevation] DECIMAL(8,2) NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	[IsPrivate] BIT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	[DeletedAt] DATETIME2 NULL,
	[IdEntityType] UNIQUEIDENTIFIER NOT NULL,
	[IdSurfaceType] UNIQUEIDENTIFIER NOT NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedBy] UNIQUEIDENTIFIER NULL,
	[DeletedBy] UNIQUEIDENTIFIER NULL,
	-- Primary Key
    CONSTRAINT [PK_Spot] PRIMARY KEY ([IdSpot]),
	-- Foreign Key
    CONSTRAINT [FK_Spot_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_User_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Spot_EntityType] FOREIGN KEY ([IdEntityType]) REFERENCES [MM_EntityType]([IdEntityType]),
	CONSTRAINT [FK_Spot_SurfaceType] FOREIGN KEY ([IdSurfaceType]) REFERENCES [MM_SurfaceType]([IdSurface]),
	-- Other Constraints
	CONSTRAINT [CK_LatitudeBounds] CHECK ([Latitude] BETWEEN -90 AND 90),
	CONSTRAINT [CK_LongitudeBounds] CHECK ([Longitude] BETWEEN -180 AND 180),
	CONSTRAINT [CK_ElevationBounds] CHECK ([Elevation] BETWEEN -15000 AND 15000),
	
)
