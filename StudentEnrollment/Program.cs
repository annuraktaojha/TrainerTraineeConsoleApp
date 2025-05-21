using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AddInstructornOffice();
            //int instructorId = 1;
            //DeleteInstructorManually(instructorId);

            ManymanyRelationship();
            //
            //TPHStatergy();
            //TPTStatergy();
            //TPCStatergy();
            using (var context = new SchoolContext())
            {
                var courses = context.Courses
             .Include(c => c.StudentEnrollments)
             .ThenInclude(e => e.Student)
             .ToList();
            }


        }

        //private static void TPCStatergy()
        //{
        //    using (var context = new SchoolContext())
        //    {
        //        context.OnlineCourses.AddRange(new OnlineCourse
        //        {
        //            Name = "Web Development .NET",
        //            Url = "http://Scholarhat.com"
        //        },

        //        new OnlineCourse
        //        {
        //            Name = "Machine Learning AI",
        //            Url = "https://Udemy.com"
        //        }
        //        );
        //        context.OnsiteCourses.AddRange(new OnsiteCourse
        //        {
        //            Name = "Data structure Algo",
        //            Address = "Bangalore-560075"
        //        });

        //        context.SaveChanges();

        //        // query
        //        var online = context.OnlineCourses.ToList();
        //        var onsite = context.OnsiteCourses.ToList();
        //        Console.WriteLine("Online courses: ");

        //        foreach (var onlineCourse in online)
        //        {
        //            Console.WriteLine($"Online COurse :{onlineCourse.Name}");
        //            Console.WriteLine($"Url Address: {onlineCourse.Url}");
        //        }
        //        Console.WriteLine("Onsite courses: ");
        //        foreach (var onsiteCourse in onsite)
        //        {
        //            Console.WriteLine($"Online COurse :{onsiteCourse.Name}");
        //            Console.WriteLine($"Url Address: {onsiteCourse.Address}");
        //        }
        //    }
        //}

        //private static void TPTStatergy()
        //{
        //    using (var context = new SchoolContext())
        //    {
        //        context.OnlineCourses.AddRange(new OnlineCourse
        //        {
        //            Name = "Web Development JAVA",
        //            Url = "http://Scholarhat.com"
        //        },

        //        new OnlineCourse
        //        {
        //            Name = "Machine Learning Python",
        //            Url = "https://Udemy.com"
        //        }
        //        );
        //        context.OnsiteCourses.AddRange(new OnsiteCourse
        //        {
        //            Name = "Data structure",
        //            Address = "Bangalore-560076"
        //        });

        //        context.SaveChanges();

        //        // query
        //        var online = context.OnlineCourses.ToList();
        //        var onsite = context.OnsiteCourses.ToList();
        //        Console.WriteLine("Online courses: ");

        //        foreach (var onlineCourse in online)
        //        {
        //            Console.WriteLine($"Online COurse :{onlineCourse.Name}");
        //            Console.WriteLine($"Url Address: {onlineCourse.Url}");
        //        }
        //        Console.WriteLine("Onsite courses: ");
        //        foreach (var onsiteCourse in onsite)
        //        {
        //            Console.WriteLine($"Online COurse :{onsiteCourse.Name}");
        //            Console.WriteLine($"Url Address: {onsiteCourse.Address}");
        //        }
        //    }
        //}

        //private static void TPHStatergy()
        //{
        //    using (var context = new SchoolContext())
        //    {
        //        context.Courses.AddRange(new OnlineCourse
        //        {
        //            Name = "Web Development",
        //            Url = "http://Scholarhat.com"
        //        },
        //        new OnsiteCourse
        //        {
        //            Name = "communication Skills",
        //            Address = "Bangalore-560076"
        //        },
        //        new OnlineCourse
        //        {
        //            Name = "Machine Learning",
        //            Url = "https://Udemy.com"
        //        }
        //        );
        //        context.SaveChanges();

        //        // query and distinguish between course types

        //        var courses = context.Courses.ToList();

        //        foreach (var course in courses)
        //        {
        //            if (course is OnlineCourse onlineCourse)
        //            {
        //                Console.WriteLine($"Online COurse :{onlineCourse.Name}");
        //                Console.WriteLine($"Url Address: {onlineCourse.Url}");
        //            }
        //            else if (course is OnsiteCourse onsiteCourse)
        //            {
        //                Console.WriteLine($"Onsite Course: {onsiteCourse.Name}, Location :{onsiteCourse.Address}");
        //            }
        //        }

        //        Console.ReadKey();
        //    }
        //}

        private static void ManymanyRelationship()
        {
            using (var context = new SchoolContext())
            {
                // seed data
                var student1 = new Student
                {
                    Name = "Alice",
                    Age = 21,
                    Email = "alice.g@domain.com"
                };
                var student2 = new Student
                {
                    Name = "Green",
                    Age = 19,
                    Email = "Green.L@domain.com"
                };

                var Course1 = new Course
                {
                    Name = "Math 101"

                };

                var Course2 = new Course
                {
                    Name = "History 101"

                };

                context.AddRange(student1, student2);
                context.Courses.AddRange(Course1, Course2);
                context.StudentEnrollments.AddRange
                    (new Entities.StudentEnrollment
                    { Student = student1, Course = Course1, Grade = 90 },

                    new Entities.StudentEnrollment
                    { Student = student1, Course = Course2, Grade = 85 },
                    new Entities.StudentEnrollment
                    { Student = student2, Course = Course1, Grade = 80 },
                    new Entities.StudentEnrollment
                    { Student = student2, Course = Course2, Grade = 95 }
                    );
                context.SaveChanges();

                //get avarge grades
                var averagegrades = context.GetAverageCourseGrades();

                foreach (var avg in averagegrades)
                {
                    var courseTitle = context.Courses.Find(avg.Key)?.Name;
                    Console.WriteLine($"Course:{courseTitle}, Average Grade:{avg.Value}");
                }
            }
        }

        //  explicit approach (when you need more control)
        public static void DeleteInstructorManually(int instructorId)
        {
            var _context = new SchoolContext();
            using var transaction =  _context.Database.BeginTransaction();
            try
            {
                // First, get and delete the office assignment if it exists
                var officeAssignment =  _context.OfficeAssignments
                    .FirstOrDefault(o => o.Id == instructorId);

                if (officeAssignment != null)
                {
                    _context.OfficeAssignments.Remove(officeAssignment);
                     _context.SaveChanges();
                }

                // Then delete the instructor
                var instructor =  _context.Instructors
                    .FirstOrDefault(i => i.Id == instructorId);

                if (instructor != null)
                {
                    _context.Instructors.Remove(instructor);
                    _context.SaveChanges();
                }

                 transaction.Commit();
            }
            catch
            {
                 transaction.Rollback();
                throw;
            }
        }
    }
}
