using Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Mappers
{
    internal static class Mapper
    {
       public static User ToUser(this IDataReader record)
       {
            if (record == null)
                throw new ArgumentNullException(nameof(record));


            return new User()
            {
                IdUser = (Guid)record["IdUser"],
                FirstName = record["FirstName"] != DBNull.Value  ? (string)record["FirstName"] : null,
                LastName = record["LastName"] != DBNull.Value ? (string)record["LastName"] : null,
                NickName = record["NickName"] != DBNull.Value ? (string)record["NickName"] : null,
                Login = (string)record["Login"],
                Email = (string)record["Email"],
                Avatar = record["Avatar"] != DBNull.Value ? (string)record["Avatar"] : null,
                CreatedAt = (DateTime)record["CreatedAt"],
                UpdatedAt = record["UpdatedAt"] != DBNull.Value ? (DateTime)record["UpdatedAt"] : null
            };                
            
       }
    }
}
