namespace PolymorphismThroughInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Circle circle = new Circle();
            circle.radious = 5;

            Console.WriteLine($"Circle Area: {circle.CalculatedArea()}");
            Rectangle rectangle = new Rectangle();
            rectangle.length = 5;
            rectangle.breadth = 10;
            Console.WriteLine($"Rectangle Area: {rectangle.CalculatedArea()}");

            Triangle triangle = new Triangle();
            triangle.Base = 5;
            triangle.Height = 10;
            Console.WriteLine($"Triangle Area: {triangle.CalculatedArea()}");
        }
    }

    interface IShapes
    {
        double CalculatedArea();
    }
    class Circle : IShapes
    {
        public double radious { get; set; }
        public double CalculatedArea()
        {
            double calculatedArea = Math.PI * radious * radious;
            return calculatedArea;
        }
    }

    class Rectangle : IShapes
    {
        public double length { get; set; }
        public double breadth { get; set; }

        public double CalculatedArea()
        {
            double calculatedArea = length * breadth;
            return calculatedArea;
        }
    }
    class Triangle : IShapes
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double CalculatedArea()
        {
            double calculatedArea = 0.5 * Base * Height;
            return calculatedArea;
        }
    }
}
