CREATE TABLE [dbo].[Track]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
	[Distance] DECIMAL(8,2) NOT NULL,
	[Elevation] DECIMAL(8,2) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL DEFAULT ('Default_Name_' + LEFT(CONVERT(NVARCHAR(36), NEWID()), 8)),
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	[IsPrivate] BIT NOT NULL DEFAULT 0,
	[PolyLine] NVARCHAR(Max) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	[DeletedAt] DATETIME2 NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[UpdatedBy] UNIQUEIDENTIFIER NULL,
	[DeletedBy] UNIQUEIDENTIFIER NULL,
	-- Primary Key
	CONSTRAINT [PK_Track] PRIMARY KEY ([IdTrack]),
	-- Foreign Keys
    CONSTRAINT [FK_Track_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Track_User_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([IdUser]),
	CONSTRAINT [FK_Track_User_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [User]([IdUser]),
	-- Other Constraints
	CONSTRAINT [CK_Track_ElevationBounds] CHECK ([Elevation] BETWEEN -15000 AND 15000),
	CONSTRAINT [CK_Track_PositiveDistance] CHECK ([Distance] > 0), 

)
