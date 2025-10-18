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
    }
}
