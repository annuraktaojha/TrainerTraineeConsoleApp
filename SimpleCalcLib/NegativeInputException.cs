
namespace SimpleCalcLib
{
    [Serializable]
    public class NegativeInputException : Exception
    {
        public NegativeInputException()
        {
        }

        public NegativeInputException(string? message) : base(message)
        {
        }

        public NegativeInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}