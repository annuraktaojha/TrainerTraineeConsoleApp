using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Entities;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SaveStudent();
            //Read Student Records
            //GetStudentRecords();

            //Update a Student Record
            //UpdateStudent();
            // FilterRecordsByAge();
            // Step 4: Delete a Student Record
            //1.Finally, add code to delete a student record:
            //DeleteStudentRecord();
            // Implement Sortng and PaginaƟon
            //1.Implement sortng by Name and paginaƟon to display students in pages of 5 records each:
            // PaginationandSorting();

            //Validation();

            //Step 2: Bulk Update Student Records
            //1.Implement a bulk update to modify the email domain for all students: 
            //BulkUpdate();

            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name ==
               "Rishi Khanna");
                if (student != null)
                {
                    student.Age = 23; // Assume this is an updated value 
                    try
                    {
                        context.SaveChanges();
                        Console.WriteLine("Student record updated.");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Concurrency conflict detected. Please  refresh and try again.");
                    }
                }
            }

        }

        private static void BulkUpdate()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students.Where(s => s.Name == "Rishi Khanna").ToList();
                foreach (var student in students)
                {
                    student.Email = student.Email.Replace("Rishi.Khanna@example.com",
                   "RishiK@newdomain.com");
                }
                context.SaveChanges();
                Console.WriteLine("Bulk update completed.");
            }
        }

        private static void Validation()
        {
            var student = new Student
            {
                Name = "John Doe",
                Age = 17, // Invalid age to trigger validation error 
                Email = "john.doe@example.com"
            };
            var context = new ValidationContext(student, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(student, context, results,
            true);
            if (isValid)
            {
                using (var dbContext = new StudentContext())
                {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    Console.WriteLine("Student record added.");
                }
            }
            else
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);

                }
            }
        }

        private static void PaginationandSorting()
        {
            using (var context = new StudentContext())
            {
                int pageNumber = 1;
                int pageSize = 5;
                var students = context.Students
                                .OrderBy(s => s.Age)
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name},Age: {student.Age}, Email: {student.Email}  ");
                }
            }
        }

        private static void FilterRecordsByAge()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students
                .Where(s => s.Age > 20)
                .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name},  Age: {student.Age}, Email: {student.Email} ");
                }
            }
        }

        private static void DeleteStudentRecord()
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    Console.WriteLine("Student record deleted.");
                }
            }
        }

        private static void UpdateStudent()
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name == "Anamika Khanna");
                if (student != null)
                {
                    student.Age = 29;
                    //student.Email = "Sanjukta.Das@example.com";
                    context.SaveChanges();
                    Console.WriteLine("Student record updated.");
                }
            }
        }

        private static void GetStudentRecords()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email} ");

                }
            }
        }

        private static void SaveStudent()
        {
            using (var context = new StudentContext())
            {
                var student = new Student
                {
                    Name = "Rishi Khanna",
                    Age = 18,
                    Email = "Rishi.Khanna@example.com"
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
            Console.WriteLine("Student record added.");
        }
    }
}
