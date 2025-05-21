using System.Linq;


namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // get all even numbers and store in a separete array and then display
            // sql : select number from numbers where number % 2 = 0
            // table: numbers
            // column: number

            // Linq


            var  evenNumbers1=from number in numbers where number %2 == 0
                             select number;

            var evenNumbers2 = numbers.Where(number => number % 2 == 0).Select(number => number);
            List<int> evenNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }

            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }




        }
    }
}
