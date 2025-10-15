using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Results
{
    internal class Result : ICqsResult
    {

        public bool IsSuccess { get; }
        public bool IsFailure { get 
            { 
                return !IsSuccess;
            } 
        }
        public string? ErrorMessage { get; }

        public Result(bool isSuccess, string? errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
