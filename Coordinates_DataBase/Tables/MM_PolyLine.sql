﻿CREATE TABLE [dbo].[MM_PolyLine]
(
	[IdPolyLine] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[IdSpot] UNIQUEIDENTIFIER NOT NULL,
	[IdTrack] UNIQUEIDENTIFIER NOT NULL,
	[Order] INT NOT NULL,	
	CONSTRAINT [PK_PolyLine] PRIMARY KEY ([IdPolyLine]),
	CONSTRAINT [UQ_PolyLine] UNIQUE ([IdSpot],[IdTrack],[Order]),
	CONSTRAINT [CK_Order_Positive] CHECK ([Order] > 0),
	CONSTRAINT [FK_PolyLine_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]),
	CONSTRAINT [FK_PolyLine_Track] FOREIGN KEY ([IdTrack]) REFERENCES [Track]([IdTrack]),
)
