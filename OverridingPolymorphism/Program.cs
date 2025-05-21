using static OverridingPolymorphism.Student;

namespace OverridingPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Professor professor1 = new Professor("Dr. John", 5);
            Professor professor2 = new Professor("Dr. Smith", 3);

            Student student1 = new Student("John", 90);
            Student student2 = new Student("Smith", 80);

            Console.WriteLine("Professor Details: ");
            professor1.Print();
            Console.WriteLine($"{professor1.GetName()} is an outstanding professor: {professor1.IsOutstanding()}");
            professor2.Print();
            Console.WriteLine($"{professor2.GetName()} is an outstanding professor: {professor2.IsOutstanding()}");

            Console.WriteLine("\nStudent Details: ");
            student1.Display();
            Console.WriteLine($"{student1.GetName()} is an outstanding student: {student1.IsOutstanding()}");
            student2.Display();
            Console.WriteLine($"{student2.GetName()} is an outstanding student: {student2.IsOutstanding()}");
            
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public Person()
        {

        }

        public Person(string name)
        {
            Name = name;

        }

        public string GetName()
        {
            return Name;
        }

        public string SetName(string name)
        {
            Name = name;
            return Name;
        }

        public virtual bool IsOutstanding()
        {
            return false;
        }
    }

    public class Student : Person
    {
        public double percentage { get; set; }
        public Student()
        {

        }
        public Student(string name, double percentage) : base(name)
        {
            this.percentage = percentage;
        }
        public override bool IsOutstanding()
        {
            return percentage > 85;
        }
        public void Display()
        {
            Console.WriteLine($"{Name} has scored {percentage}%");
        }

        public class Professor : Person
        {
            public int booksPublished { get; set; }
            public Professor()
            {
            }
            public Professor(string name, int booksPublished) : base(name)
            {
                this.booksPublished = booksPublished;
            }
            public override bool IsOutstanding()
            {
                return booksPublished > 4;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} has published {booksPublished} books");
            }

        }
    }
}
