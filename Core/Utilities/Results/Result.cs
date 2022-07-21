
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success) //işlemle birlikte
        {
            Message = message;
        }
        public Result(bool success) //Sade işlem
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}