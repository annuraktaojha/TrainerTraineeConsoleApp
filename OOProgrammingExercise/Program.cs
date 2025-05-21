using System.Net;

namespace OOProgrammingExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company("ABC", new System.DateTime(2021, 1, 1));

            company.AddBranch("Corporate Office");
            company.AddBranch("RegisteredOffice");
            Employee employee1 = new Employee()
            {
                Name = "John",
                Address = "123, 1st Street, New York",
                Age = 25,
                Basic = 10000,
                EmpId = 1,
                Experience = 2
            };
            Employee employee2 = new Employee()
            {
                Name = "Smith",
                Address = "456, 2nd Street, New York",
                Age = 30,
                Basic = 20000,
                EmpId = 2,
                Experience = 4
            };
            Employee employee3 = new Employee()
            {
                Name = "Peter",
                Address = "789, 3rd Street, New York",
                Age = 35,
                Basic = 30000,
                EmpId = 3,
                Experience = 6
            };
            Employee employee4 = new Employee()
            {
                Name = "Paul",
                Address = "101, 4th Street, New York",
                Age = 40,
                Basic = 40000,
                EmpId = 4,
                Experience = 8
            };
            company.Employees.Add(employee1);
            company.Employees.Add(employee2);
            company.Employees.Add(employee3);
            company.Employees.Add(employee4);
            Customer customer1 = new Customer()
            {
                Name = "John",
                Address = "123, 1st Street, New York",
                Age = 25,
                Email = "John@gmailcom"
            };
            Customer customer2 = new Customer()
            {
                Name = "Smith2",
                Address = "1234, 11th Street, New York",
                Age = 35,
                Email = "John@gmailcom"
            };

            company.Customers.Add(customer1);
            company.Customers.Add(customer2);

            company.Branches[0].Employees.Add(employee1);
            company.Branches[0].Employees.Add(employee2);
            company.Branches[1].Employees.Add(employee3);
            company.Branches[1].Employees.Add(employee4);

            company.Branches[0].Customers.Add(customer1);
            company.Branches[1].Customers.Add(customer2);

            Console.WriteLine($"Total Salary Payout: {company.GetTotalSalaryPayout()}");
            Console.WriteLine($"Total Employees: {company.TotalEmployees()}");

            Console.WriteLine($"Total Customers: {company.TotalCustomers()}");
            company.Branches[0].Employees.ForEach(e => Console.WriteLine($"Employee Name: {e.Name}"));
            company.Branches[1].Employees.ForEach(e => Console.WriteLine($"Employee Name: {e.Name}"));
            company.Branches[0].Customers.ForEach(c => Console.WriteLine($"Customer Name: {c.Name}"));
            company.Branches[1].Customers.ForEach(c => Console.WriteLine($"Customer Name: {c.Name}"));

            Console.WriteLine($"salary of an Employee : {company.GetEmployee(company.Employees[0].EmpId).GetSalary()}");

        }
    }

   
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

    }

    public class Employee : Person
    {
        public double Basic { get; set; }

        public int EmpId { get; set; }

        public double Experience { get; set; }

        public double GetSalary()
        {
            return Basic + SalaryCalculator.CalculateSalary(Experience, Basic);
        }


    }

    public  class Customer : Person
    {
        public string Email { get; set; }
        public int CustomerId { get; set; }
    }

    public class SalaryCalculator
    {
        public static double CalculateSalary(double Experience, double Basic)
        {
            if (Experience <= 2)
            {
                return Basic * 30 / 100;

            }
            else if (Experience <= 4)
            {

                return Basic * 40 / 100;


            }
            else if (Experience <= 6)
            {
                return Basic * 50 / 100;
            }
            else if (Experience > 6)
            {
                return Basic * 65 / 100;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Company
    {
        public string Name { get; set; }

        public DateTime IncorporatedDate { get; set; }

        public List<Branch> Branches { get; set; }

        public Company(string name, DateTime incorporatedDate)
        {
            Name = name;
            IncorporatedDate = incorporatedDate;
            Branches= new List<Branch>();
        }

        public void AddBranch(string branchName)
        {
            Branches.Add(new Branch(branchName));
        }

        public Employee GetEmployee(int EmpId)
        {
            return Employees.Find(e => e.EmpId == EmpId);
        }

        public double GetTotalSalaryPayout()
        {
            return Employees.Sum(e => e.GetSalary());
        }

        public int TotalEmployees()
        {
            return Employees.Count;
        }

        public int TotalCustomers()
        {
            return Customers.Count;
        }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

    }

    public class Branch
    {
        public string Name { get; set; }
        
        
        public Branch(string name)
        {
            Name = name;
            
        }
        //public double GetTotalSalaryPayout()
        //{
        //    return Employees.Sum(e => e.GetSalary());
        //}
        //public int TotalEmployees()
        //{
        //    return Employees.Count;
        //}
        //public int TotalCustomers()
        //{
        //    return Customers.Count;
        //}
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
