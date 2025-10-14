CREATE TABLE [dbo].[MM_Rating_Track]
(
	[IdTrack] UNIQUEIDENTIFIER NOT NULL, 
	[IdRating] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Rating_Track] PRIMARY KEY ([IdTrack], [IdRating]),
	CONSTRAINT [FK_RatingTrack_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
	CONSTRAINT [FK_RatingTrack_Rating] FOREIGN KEY ([IdRating]) REFERENCES [Rating]([IdRating])
)
