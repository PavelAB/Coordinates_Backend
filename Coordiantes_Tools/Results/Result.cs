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

    internal class Result<TResult> : ICqsResult<TResult>
    {
        private readonly TResult? _content;

        public bool IsSuccess { get; }
        public bool IsFailure { get { return !IsSuccess; } }
        public string? ErrorMessage { get; }
        public TResult? Content 
        {
            get 
            {
                if (IsFailure)
                    throw new InvalidOperationException();

                return _content;
            } 
        }
        internal Result(bool isSuccess, TResult? content, string? errorMessage)
        {
            IsSuccess = isSuccess;
            _content = content;
            ErrorMessage = errorMessage;
        }
    }


}
