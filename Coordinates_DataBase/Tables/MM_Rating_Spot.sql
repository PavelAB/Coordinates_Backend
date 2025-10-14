CREATE TABLE [dbo].[MM_Rating_Spot]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL, 
	[IdRating] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Rating_Spot] PRIMARY KEY ([IdSpot], [IdRating]),
	CONSTRAINT [FK_RatingSpot_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]),
	CONSTRAINT [FK_RatingSpot_Rating] FOREIGN KEY ([IdRating]) REFERENCES [Rating]([IdRating])
)
