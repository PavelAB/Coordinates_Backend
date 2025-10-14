CREATE TABLE [dbo].[MM_Comment_Spot]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL, 
	[IdComment] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Comment_Spot] PRIMARY KEY ([IdSpot], [IdComment]),
	CONSTRAINT [FK_CommentSpot_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]),
	CONSTRAINT [FK_CommentSpot_Comment] FOREIGN KEY ([IdComment]) REFERENCES [Comment]([IdComment])
)
