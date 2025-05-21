
namespace SimpleCalcLib
{
    [Serializable]
    public class ZeroInputException : Exception
    {
        public ZeroInputException()
        {
        }

        public ZeroInputException(string? message) : base(message)
        {
        }

        public ZeroInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}