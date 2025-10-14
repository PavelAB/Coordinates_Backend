CREATE TABLE [dbo].[MM_SpotValidation]
(
	[IdSpot] UNIQUEIDENTIFIER NOT NULL, 
	[IdValidator] UNIQUEIDENTIFIER NOT NULL,
	[IsValid] BIT NOT NULL DEFAULT 1,
	[ValidatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
	CONSTRAINT [PK_SpotValidation] PRIMARY KEY ([IdSpot], [IdValidator]),
	CONSTRAINT [FK_SpotValidation_Spot] FOREIGN KEY ([IdSpot]) REFERENCES [Spot]([IdSpot]), 
	CONSTRAINT [FK_SpotValidation_User] FOREIGN KEY ([IdValidator]) REFERENCES [User]([IdUser]) 
)
