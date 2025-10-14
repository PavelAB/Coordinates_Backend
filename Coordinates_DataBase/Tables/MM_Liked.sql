CREATE TABLE [dbo].[MM_Liked]
(
	[IdComment] UNIQUEIDENTIFIER NOT NULL, 
	[IdUser] UNIQUEIDENTIFIER NOT NULL,
	[Like] BIT NULL DEFAULT 1,
	CONSTRAINT [PK_Liked] PRIMARY KEY ([IdComment], [IdUser]),
	CONSTRAINT [FK_Liked_Comment] FOREIGN KEY ([IdComment]) REFERENCES [Comment]([IdComment]),
	CONSTRAINT [FK_Liked_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([IdUser])
)
