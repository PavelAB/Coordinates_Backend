using Coordiantes_Tools.Results;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Commands.Track;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class TrackService : BaseService, ITrackRepository
    {
        public TrackService(EnvConfig env): base(env)
        {
            
        }

        public ICqsResult Execute(CreateTrackCommand command)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "dbo.SP_Track_Create";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Distance", command.Distance);
                    sqlCommand.Parameters.AddWithValue("@Ascent", command.Ascent);
                    sqlCommand.Parameters.AddWithValue("@Descent", command.Descent);
                    if(command.Name is not null)
                        sqlCommand.Parameters.AddWithValue("@Name", command.Name);
                    if(command.IsPrivate is not null)
                        sqlCommand.Parameters.AddWithValue("@IsPrivate", command.IsPrivate);
                    sqlCommand.Parameters.AddWithValue("@PolyLine", command.PolyLine);
                    sqlCommand.Parameters.AddWithValue("@CreatedBy", command.CreatedBy);
                    sqlCommand.Parameters.AddWithValue("@Surface", command.Surface);
                    sqlCommand.Parameters.AddWithValue("@EntityType", command.EntityType);


                    try
                    {
                        connection.Open();
                        Guid newTrack = (Guid)sqlCommand.ExecuteScalar();
                        Console.WriteLine($"IdTrack : {newTrack}");
                        return ICqsResult.Success();


                    }
                    catch (Exception e)
                    { 
                        return ICqsResult.Failure(e.Message);
                    }
                }
            }
        }
    }
}
