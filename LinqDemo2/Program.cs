namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // excute step1 

           List<int> numbers= new List<int>() {1,2,3,4,5, 6, 7, 8, 9 };
            // get all even numbers 

           // var evenNumbers = numbers.Where(number => number % 2 == 0).Select(number => number);
            // step 3
            var even= (from number in numbers
                      where IsEven(number)//number % 2 == 0 
                      select number).ToList(); // defered execution will happen here


            // step 2
            numbers.Add(10);


            // step 4
            foreach (var number in even)
            {
                Console.WriteLine(number);
            }
        }

        public static bool IsEven(int number)
        {
            Console.WriteLine("Checking if {0} is even", number);
            return number % 2 == 0;
        }
    }
}
