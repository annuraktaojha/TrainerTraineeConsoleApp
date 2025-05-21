namespace DelegateBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringOperations stringOperations = new StringOperations();
            string input = "Hello, World!";
            StringModifier stringModifier = new StringModifier(ToUpperCase);
            stringModifier += Reverse;

            StringModifier stringModifier1 = new StringModifier(ToLowerCase);

            StringModifier stringModifier2 = new StringModifier(Reverse);

            StringModifier stringModifier3;

            stringModifier3 = stringModifier  + stringModifier2;
            // stringModifier += ToLowerCase;

            string result = stringOperations.ModifyString(input, stringModifier);

            Console.WriteLine($" The cascade modified string is {stringOperations.ModifyString(input,stringModifier3)}");

            Console.WriteLine($"The modified string is :{result}");
        }

        public static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string ToLowerCase(string input)
        {
            return input.ToLower();
        }

        public static string Reverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }

    public delegate string StringModifier(string input);

    public class StringOperations
    {
        public string ModifyString(string input, StringModifier stringModifier)
        {
            return stringModifier(input);
        }
    }
}
