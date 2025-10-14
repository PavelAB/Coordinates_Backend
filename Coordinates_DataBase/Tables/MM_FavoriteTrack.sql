CREATE TABLE [dbo].[MM_FavoriteTrack]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL,
	[IdUser] UNIQUEIDENTIFIER NOT NULL,
	[IsFavorite] BIT NOT NULL DEFAULT 1,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	CONSTRAINT [PK_FavoriteTrack] PRIMARY KEY ([IdTrack], [IdUser]),
	CONSTRAINT [FK_FavoriteTrack_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_FavoriteTrack_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([IdUser])
)
