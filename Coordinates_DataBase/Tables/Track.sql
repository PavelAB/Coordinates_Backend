CREATE TABLE [dbo].[Track]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	-- BEGIN CONSTRAINT VALUE BEETWEEN OK 
	[Distance] DECIMAL(8,2) NOT NULL,
	[Elevation] Decimal(8,2) NOT NULL,
	-- END
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	[IsPrivate] BIT NOT NULL DEFAULT 0,
	-- FK IdPolyLine manyToOne, change not null
	[IdPolyLine] UNIQUEIDENTIFIER NULL,
	[PolyLine] NVARCHAR(Max) NOT NULL,
	-- FK EntityType manyToOne, change not null, constaint default value 'None'
	[IdEntityType] UNIQUEIDENTIFIER NULL,
	-- FK SurfaceType manyToOne, change not null, constaint default value 'None'
	[IdSurfaceType] UNIQUEIDENTIFIER NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	[DeletedAt] DATETIME2 NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedBy] UNIQUEIDENTIFIER NULL,
	[DeletedBy] UNIQUEIDENTIFIER NULL,
	CONSTRAINT [PK_Track] PRIMARY KEY ([IdTrack]),
    CONSTRAINT [FK_Track_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Track_User_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Track_User_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [User]([IdUser])
)
