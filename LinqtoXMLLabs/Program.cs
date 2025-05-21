using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqtoXMLLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load the entire XML document and display the xml content on to the screen
            var LoadEmployee = XDocument.Load("XMLFile1.xml");
            var employees = from employee in LoadEmployee.Descendants("Employees")
                            select employee;
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            // show only the name of all Employees 

             var employeeNames = from employee in LoadEmployee.Descendants("Employee")
                                 select employee.Element("Name").Value;

            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }

            //Show the Employee name and ID of all the employees 

            var employeeDetails = from employee in LoadEmployee.Descendants("Employee")
                                  select new
                                  {
                                      Name = employee.Element("Name").Value,
                                      ID = employee.Element("EmpId").Value

                                  };

            foreach (var emp in employeeDetails)
            {
                Console.WriteLine(emp.ID + ", " + emp.Name   );
                Console.WriteLine();
            }
            //Console.ReadLine();

            // List the names of all female employees only 

            //var FemaleEmployess = from employee in LoadEmployee.Descendants("Employee")
            //                      where employee.Element("Sex").Value == "Female"
            //                      select new
            //                      {
            //                          Name = employee.Element("Name").Value,
            //                          ID = employee.Element("EmpId").Value
            //                      };

            //foreach(var emp in FemaleEmployess)
            //{
            //    Console.WriteLine("Female employess : "+ emp.ID + ", " + emp.Name);
            //    Console.WriteLine();
            //}

            // List all the Home Phone numbers 

            //var HomePhoneNumbers = from employee in LoadEmployee.Descendants("Employee")
            //                       where employee.Element("Phone")?.Attribute("Type")?.Value == "Home"
            //                       select employee.Element("Phone").Value;

            //                        //select employee.Element("Phone Type=\"Home\"").Value;
            //foreach (var emp in HomePhoneNumbers) {
            //    Console.WriteLine(emp);
            //}

            // List all the employee names living in ‘Alta’ city 

            //var EmployeesInAlta = from employee in LoadEmployee.Descendants("Employee")
            //                          where employee.Element("Address").Element("City").Value == "Alta"
            //                          select employee.Element("Name").Value;
            //foreach (var emp in EmployeesInAlta)
            //{
            //    Console.WriteLine(emp);
            //}

            //List and sort all the Zip codes

            //var ZipCodes = (from employee in LoadEmployee.Descendants("Employee")
            //                select employee.Element("Address").Element("Zip").Value).Distinct().OrderBy(zip => zip);
            //foreach (var zip in ZipCodes)
            //{
            //    Console.WriteLine(zip);
            //}

            // List  employee based  on sorted zip codes

            //var EmployeesBasedOnZip = from employee in LoadEmployee.Descendants("Employee")
            //                          orderby employee.Element("Address").Element("Zip").Value
            //                          select employee;
            //foreach (var emp in EmployeesBasedOnZip)
            //{
            //    Console.WriteLine(emp);
            //}

            //List the details of first 2 employees

            //var FirstTwoEmployees = (from employee in LoadEmployee.Descendants("Employee")
            //                         select employee).Take(2);
            //foreach (var emp in FirstTwoEmployees)
            //{
            //    Console.WriteLine(emp);
            //}

            // Count the number of employees living in the state ‘CA’ 
            var EmployeesInCA = (from employee in LoadEmployee.Descendants("Employee")
                                 where employee.Element("Address").Element("State").Value == "CA"
                                 select employee).Count();
            Console.WriteLine(EmployeesInCA);

            //List all female employee names and city only

            var FemalelivesInCity = from employee in LoadEmployee.Descendants("Employee")
                                     where employee.Element("Sex").Value == "Female"
                                     select new
                                     {
                                         Name = employee.Element("Name").Value,
                                         City = employee.Element("Address").Element("City").Value,
                                         Gender= employee.Element("Sex").Value
                                     };
            foreach (var emp in FemalelivesInCity)
            {
                Console.WriteLine(emp.Name + ", " + emp.City + ", " + emp.Gender);

            }

            Console.ReadLine();

            // Console.WriteLine($"All Employees: {employees}");
        }
    }
}
