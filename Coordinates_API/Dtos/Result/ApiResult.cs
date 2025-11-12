using Coordiantes_Tools.Results;

namespace Coordinates_API.Dtos.Result
{
    internal class Result : IApiResult
    {

        public bool IsSuccess { get; }
        public bool IsFailure
        {
            get
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

    internal class Result<TResult> : IApiResult<TResult>
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
                    return default(TResult);

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