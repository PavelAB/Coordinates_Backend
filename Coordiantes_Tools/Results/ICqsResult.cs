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
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        TResult Data { get; }
    }
}
