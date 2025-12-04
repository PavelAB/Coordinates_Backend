CREATE PROCEDURE [dbo].[SP_Track_Get]
	@IdTrack UNIQUEIDENTIFIER = NULL,
	@Distance DECIMAL(8,2) = NULL,
	@Ascent DECIMAL(8,2) = NULL,
	@Descent DECIMAL(8,2) = NULL,
	@Name NVARCHAR(50) = NULL,
	@CreatedBy UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SELECT 
		Track.IdTrack,
		Distance,
		Ascent,
		Descent,
		IsDeleted,
		IsPrivate,
		Track.[Name] as 'Name',
		PolyLine,
		CreatedAt,
		UpdatedAt,
		DeletedAt,
		CreatedBy,
		UpdatedBy,
		DeletedBy,
		Surface.IdSurface as IdSurface, 
		Surface.SurfaceType as SurfaceType,
		EntityType.IdEntityType as IdEntityType,
		EntityType.Name as EntityName
	FROM 
		Track JOIN MM_Track_Surface
		ON Track.IdTrack = MM_Track_Surface.IdTrack
		JOIN Surface
		ON MM_Track_Surface.IdSurface = Surface.IdSurface
		JOIN MM_Track_EntityType
		ON Track.IdTrack = MM_Track_EntityType.IdTrack
		JOIN EntityType
		ON MM_Track_EntityType.IdEntityType = EntityType.IdEntityType
	WHERE 
		(@IdTrack IS NULL OR Track.IdTrack = @IdTrack)
		AND (@Distance IS NULL OR Distance > @Distance)
		AND (@Ascent IS NULL OR Ascent > @Ascent)
		AND (@Descent IS NULL OR Descent > @Descent)
		AND (@Name IS NULL OR Track.[Name] = @Name)
		AND (@CreatedBy IS NULL OR CreatedBy = @CreatedBy)
		
END
