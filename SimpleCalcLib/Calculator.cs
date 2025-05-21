using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalcLib
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            int result = calc.Sum(10, 20);
            Console.WriteLine($"Sum of two nos are {result}");
        }

        private IResultlogger logger;
        public Calculator()
        {
            
        }

        public Calculator(IResultlogger resultlogger)
        {
            this.logger = resultlogger;
        }

        public int Sum(int a, int b)
        {
            // non-negative non-zero non-odd numers -- throws excetion
            if(a<0 || b<0) 
               throw new NegativeInputException();

            if (b == 0 || a == 0)

                throw new ZeroInputException();

            if (a % 2 != 0 || b % 2 != 0)

                throw new OddInputException();

            int result = a + b;

          //  FileLogger.SaveResult(a,b,result);
           logger.SaveResult(a,b,result);

            return result;
        }
    }

    public interface IResultlogger 
    {
        void SaveResult(int input1, int input2, int result);
    
    }

    public class FileLogger : IResultlogger
    {
        public  void SaveResult(int i1, int ip2, int result)
        {
            string data = $"{i1 + +ip2} = {result}";// 10+20=30
            File.WriteAllText("Z:\\result.txt", data);
        }
    }
}
