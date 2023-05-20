using System.Text.Json;

namespace Utility.Exceptions.Models
{
    public class CustomException : Exception
    {
        public CustomException(ErrorCodes.ErrorCodes errorCode, string message) : base(
            JsonSerializer.Serialize(new
            {
                ErrorCode = errorCode,
                Message = message
            }))
        { }
    }
}
