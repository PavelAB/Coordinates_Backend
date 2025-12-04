using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;
using System.Runtime.CompilerServices;

namespace Coordinates_API.Mappers
{
    internal static class Mapper
    {
        public static IApiResult<TResult> ToIApiResult<TResult>(this ICqsResult<TResult> result)
        {
            if(result is null)
                throw new ArgumentNullException(nameof(result));

            if (result.IsFailure)
            {
                return IApiResult<TResult>.Failure(result.ErrorMessage);
            }

            return IApiResult<TResult>.Success(result.Content);
            
        }

        public static IApiResult ToIApiResult(this ICqsResult result)
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));

            if (result.IsFailure)
            {
                return IApiResult.Failure(result.ErrorMessage);
            }

            return IApiResult.Success();
        }
    }
}
