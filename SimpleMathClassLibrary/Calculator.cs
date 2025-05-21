namespace SimpleMathClassLibrary
{
    public class Calculator

    {
        /// <summary>
        /// This method accepts 2 integers and returns their sum
        /// </summary>
        /// <param name="a">first int number</param>
        /// <param name="b">second int numbers</param>
        /// <returns>the sum of two numbers</returns>
        public static int FindSum(int a, int b)
        {
            //try
            //{
                //a = 10;
                //b = 0;
                //int c = a / b;
                if(b == 0 || a==0)
                {
                    throw new InvalidInputException("provide non-zero inputs");
                }
                if (b < 0 || a <0)
                {
                    throw new InvalidInputException("provide non-negative inputs");
                }
                // odd numbers
                return a + b;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    // log the exception
            //    // framework log4net, NLog, Serilog
            //    //convert the exception to Custom Exception
            //    UnabletoFindSumException newEx = new UnabletoFindSumException("Database issue, please try later",ex);
            //    throw newEx;
            //}
        }
    }

    public class UnabletoFindSumException : ApplicationException
    {
        //public UnabletoFindSumException()
        //{
            
        //}

        //public UnabletoFindSumException(string msg):base(msg)
        //{
            
       // }
        public UnabletoFindSumException(string? msg =null, Exception? innerException =null):base(msg)
        {
            
        }
    }

    public class  InvalidInputException:ApplicationException
    {
        public InvalidInputException(string msg):base(msg)
        {
            
        }

    }

}
