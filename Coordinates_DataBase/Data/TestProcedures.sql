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


--EXEC dbo.SP_Spot_Create
--	@IdUser = '5A381BFB-2EDA-4AE2-A896-FF47B7A163E2',
--	@IdEntityType = '1E911C43-CC6E-4C64-8214-59C10F3D85FB',
--	@IdSurfaceType = '82319C4A-4F20-4E8A-828A-807DB23DDFE0',
--    @Latitude = 10.56,
--	@Longitude = 10.56,
--	@Elevation = 95.56
