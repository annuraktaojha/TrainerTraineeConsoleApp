
namespace SimpleCalcLib
{
    [Serializable]
    public class OddInputException : Exception
    {
        public OddInputException()
        {
        }

        public OddInputException(string? message) : base(message)
        {
        }

        public OddInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}