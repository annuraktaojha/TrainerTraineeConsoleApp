
using SimpleMathClassLibrary;

namespace ExceptionDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //accepts 2 ints and calculate sum and display
            while(true)
            {
                try
                {
                    int FirstNum;
                    int SecondNum;

                    Console.WriteLine("Enter First Number: ");
                    FirstNum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Second Number");
                    SecondNum = int.Parse(Console.ReadLine());

                    //open db conn
                    //insert data



                    int SumNum = Calculator.FindSum(FirstNum, SecondNum);

                    Console.WriteLine("The Sum of {0} and {1} is {2}", FirstNum, SecondNum, SumNum);
                   
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter only Numbers");
                }
                //catch (OverflowException ex)
                //{
                //    Console.WriteLine("enter small numbers");
                //}
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                }
              
            }
         
        }
    }
}
