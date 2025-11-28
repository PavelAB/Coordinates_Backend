using Coordiantes_Tools.Results;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Commands.Spot;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Coordinates_CQS_Domain.Entities.Spot;
using Coordinates_CQS_Domain.Queries.Spot;
using Coordinates_CQS_Domain.Mappers;

namespace Coordinates_CQS_Domain.Services
{
    public class SpotService : BaseService, ISpotRepository
    {
        public SpotService(EnvConfig env): base(env)
        {

        }

        public ICqsResult Execute(CreateSpotCommand command)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "dbo.SP_Spot_Create";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdUser", command.CreatedBy);
                    sqlCommand.Parameters.AddWithValue("@EntityType", command.EntityType);
                    sqlCommand.Parameters.AddWithValue("@Surface", command.SurfaceType);
                    sqlCommand.Parameters.AddWithValue("@Latitude", command.Latitude);
                    sqlCommand.Parameters.AddWithValue("@Longitude", command.Longitude);
                    sqlCommand.Parameters.AddWithValue("@Elevation", command.Elevation);
                    if (command.Name is not null)
                        sqlCommand.Parameters.AddWithValue("@Name", command.Name);


                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        return ICqsResult.Success();
                    }
                    catch (Exception e)
                    {
                        return ICqsResult.Failure(e.Message);
                    }

                }
            }
        }
        
        public async ValueTask<ICqsResult<List<Spot_Get>>> ExecuteAsync(GetSpotQuery query)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.SP_Spot_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdSpot", query.IdSpot);
                    command.Parameters.AddWithValue("@Latitude", query.Latitude);
                    command.Parameters.AddWithValue("@Longitude", query.Longitude);
                    command.Parameters.AddWithValue("@Name", query.Name);
                    command.Parameters.AddWithValue("@CreatedBy", query.CreatedBy);
                    command.Parameters.AddWithValue("@IsPrivate", query.IsPrivate);

                    Dictionary<Guid, Spot_Get> DictionaryOfSpots = new();

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                Spot_Get spot = reader.ToSpot_Get();

                                if (DictionaryOfSpots.ContainsKey(spot.IdSpot))
                                {
                                    if (!DictionaryOfSpots[spot.IdSpot].Surfaces.Any(s => s.IdSurface == spot.Surfaces?[0].IdSurface))
                                        DictionaryOfSpots[spot.IdSpot].Surfaces.Add(spot.Surfaces[0]);

                                    if (!DictionaryOfSpots[spot.IdSpot].EntityTypes.Any(et => et.IdEntityType == spot.EntityTypes?[0].IdEntityType))
                                        DictionaryOfSpots[spot.IdSpot].EntityTypes.Add(spot.EntityTypes[0]);
                                }
                                else
                                {
                                    DictionaryOfSpots.Add(spot.IdSpot, spot);

                                }

                            }
                        }

                        List<Spot_Get> spots = DictionaryOfSpots.Values.ToList();


                        if (spots is null)
                            return ICqsResult<List<Spot_Get>>.Failure("No content");
                        else
                            return ICqsResult<List<Spot_Get>>.Success(spots);
                    }
                    catch (Exception e)
                    {
                        return ICqsResult<List<Spot_Get>>.Failure(e.Message);
                    }                    
                }
            }    
        }

        public async ValueTask<ICqsResult<List<Spot_Light>>> ExecuteAsync(GetSpotLight query)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.SP_Spot_Get_Light";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdSpot", query.IdSpot);
                    command.Parameters.AddWithValue("@Latitude", query.Latitude);
                    command.Parameters.AddWithValue("@Longitude", query.Longitude);
                    command.Parameters.AddWithValue("@Name", query.Name);
                    command.Parameters.AddWithValue("@CreatedBy", query.CreatedBy);
                    command.Parameters.AddWithValue("@IsPrivate", query.IsPrivate);

                    try
                    {
                        connection.Open();

                        List<Spot_Light> spots = [];

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                Spot_Light tempSpot = reader.ToSpot_Light();
                                spots.Add(tempSpot);
                            }

                            return ICqsResult<List<Spot_Light>>.Success(spots);
                        }
                    }
                    catch (Exception e)
                    {
                        return ICqsResult<List<Spot_Light>>.Failure(e.Message);
                    }
                }
            }
        }
    }
}
