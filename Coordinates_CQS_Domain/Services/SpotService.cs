﻿using Coordiantes_Tools.Results;
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

        
        public async ValueTask<ICqsResult<Spot_Get>> ExecuteAsync(GetSpotQuery query)
        {
            using(SqlConnection connection = new(_connectonString))
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
                    command.Parameters.AddWithValue("@IsPrivate", query.IsPriivate);

                    Spot_Get spot = null;

                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            spot = reader.ToSpot_Get();
                        }
                    }

                    if (spot is not null)
                        return ICqsResult<Spot_Get>.Success(spot);
                    else
                        return ICqsResult<Spot_Get>.Failure("No content");
                }
            }    
        }
    }
}
