using Coordiantes_Tools.Results;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Coordinates_CQS_Domain.Commands.Users;
using Coordinates_CQS_Domain.Mappers;
using Coordinates_CQS_Domain.Entities.User;

namespace Coordinates_CQS_Domain.Services
{
    public class AuthService: BaseService, IAuthRepository
    {

        public AuthService(EnvConfig env) : base(env)
        {

        }

        public ICqsResult Execute(CreateUserCommand command)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "dbo.SP_User_Create";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@nickName", command.NickName);
                    sqlCommand.Parameters.AddWithValue("@email", command.Email);
                    sqlCommand.Parameters.AddWithValue("@login", command.Login);
                    sqlCommand.Parameters.AddWithValue("@userPassword", command.Password);


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

        public ICqsResult<User> Execute(CheckPasswordCommand command)
        {
            using (SqlConnection connection = new(_connectonString))
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "dbo.SP_User_CheckPassword";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@login", command.Login);
                    sqlCommand.Parameters.AddWithValue("@password", command.Password);

                    User user = null;
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user = reader.ToUser();
                            }
                        }
                        //Console.WriteLine("USER:"+ user.IdUser);
                        if (user is not null)
                        {
                            return ICqsResult<User>.Success(user);
                        }
                        else
                            return ICqsResult<User>.Failure("No content");

                    }
                    catch (Exception e)
                    {

                        return ICqsResult<User>.Failure(e.Message);
                    }
                    

                }
            }
        }


    }
}
