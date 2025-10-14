CREATE TABLE [dbo].[MM_TrackValidation]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL,
	[IdValidator] UNIQUEIDENTIFIER NOT NULL,
	[IsValid] BIT NOT NULL DEFAULT 1,
	[ValidatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	CONSTRAINT [PK_TrackValidation] PRIMARY KEY ([IdTrack], [IdValidator]),
	CONSTRAINT [FK_TrackValidation_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_TrackValidation_User] FOREIGN KEY ([IdValidator]) REFERENCES [User]([IdUser])


)
