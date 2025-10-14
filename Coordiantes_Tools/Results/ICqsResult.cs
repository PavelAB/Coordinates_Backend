using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Results
{
    internal interface ICqsResult
    {
        bool IsSuccess { get; }
        bool IsFailure {  get; }
        string ErrorMessage { get; }
    }
    internal interface ICqsResult<TResult>
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        TResult Data { get; }
    }
}
