CREATE TABLE [dbo].[MM_Comment_Track]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL, 
	[IdComment] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Comment_Track] PRIMARY KEY ([IdTrack], [IdComment]),
	CONSTRAINT [FK_CommentTrack_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_CommentTrack_Comment] FOREIGN KEY ([IdComment]) REFERENCES [Comment]([IdComment])
)
