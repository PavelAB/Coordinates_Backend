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

-- Create User

INSERT INTO [User] (FirstName, LastName, NickName, Login, Email, Password) VALUES (
    'Pavel',
    'Bezukladnikov',
    'BestNick',
    'B.pavel',
    'Test@test.com',
    'TestPassword');

-- Create Spot

EXEC dbo.CreateSpot

-- Create Track

EXEC dbo.CreateTrack