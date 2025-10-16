using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Results
{
    public interface ICqsResult
    {
        static ICqsResult Success()
        {
            return new Result(true, null);
        }
        static ICqsResult Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }

        bool IsSuccess { get; }
        bool IsFailure {  get; }
        string ErrorMessage { get; }
    }
    public interface ICqsResult<TResult>
    {
        static ICqsResult<TResult> Success(TResult? content)
        {
            return new Result<TResult>(true, content, null);
        }
        static ICqsResult<TResult> Failure(string errorMessage)
        {
            return new Result<TResult>(false, default, errorMessage);
        }
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        TResult Content{ get; }
    }
}
