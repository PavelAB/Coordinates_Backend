using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;

namespace Coordinates_API.Dtos.Result
{
    public interface IApiResult
    {
        static IApiResult Success()
        {
            return new Result(true, null);
        }
        static IApiResult Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }

        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
    }
    public interface IApiResult<TResult>
    {
        static IApiResult<TResult> Success(TResult? content)
        {
            return new Result<TResult>(true, content, null);
        }
        static IApiResult<TResult> Failure(string errorMessage)
        {
            return new Result<TResult>(false, default, errorMessage);
        }
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        TResult Content { get; }
    }
}
