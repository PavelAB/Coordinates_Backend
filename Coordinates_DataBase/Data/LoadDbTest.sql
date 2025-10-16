/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Create EntityType

EXEC dbo.CreateEntityType @Name = 'No Information'
EXEC dbo.CreateEntityType @Name = 'Cyclist'
EXEC dbo.CreateEntityType @Name = 'Runner'
EXEC dbo.CreateEntityType @Name = 'Hiking'
EXEC dbo.CreateEntityType @Name = 'Tourist'


-- Create SurfaceType

EXEC dbo.CreateSurfaceType @SurfaceType = 'No Information'
EXEC dbo.CreateSurfaceType @SurfaceType = 'Asphalt'
EXEC dbo.CreateSurfaceType @SurfaceType = 'Gravel'
EXEC dbo.CreateSurfaceType @SurfaceType = 'Concrete'
EXEC dbo.CreateSurfaceType @SurfaceType = 'Dirt'


-- Create User

EXEC dbo.SP_User_Create 
    @nickName = 'BestNick', 
    @email = 'Test@test.com',
    @login = 'B.pavel',
    @userPassword = 'TestPassword';


-- Create Spot

EXEC dbo.CreateSpot
    @Latitude = 89.56,
	@Longitude = 90.56,
	@Elevation = 899.56
EXEC dbo.CreateSpot
    @Latitude = 79.56,
	@Longitude = 80,
	@Elevation = 999.56

-- Create Track

EXEC dbo.CreateTrack @Distance = 1000.89, @Elevation = 100.05

-- Create PolyLine

EXEC dbo.CreatePolyLine

-- Create SpotValidation

EXEC dbo.CreateSpotValidation

-- Create FavoriteSpot

EXEC dbo.CreateFavoriteSpot

-- Create FavoriteTrack

EXEC dbo.CreateFavoriteTrack

-- Create TrackValidation

EXEC dbo.CreateTrackValidation

-- Create Comment

EXEC dbo.CreateComment @Body = 'My best comment';

-- Create CommentSpot

EXEC dbo.CreateCommentSpot

-- Create CommentTrack

EXEC dbo.CreateCommentTrack

-- Create Like

EXEC dbo.CreateLike

-- Create Rating

EXEC dbo.CreateRating @Score = 8;

-- Create RatingSpot

EXEC dbo.CreateRatingSpot;

-- Create RatingTrack

EXEC dbo.CreateRatingTrack;