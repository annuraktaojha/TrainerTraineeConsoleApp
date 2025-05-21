namespace SkillAssureTrainingModel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SkillAssureTrainingModel trainingModel = new SkillAssureTrainingModel
            {
                ClientName = "TechCorp",
                Iterations = new List<Iteration>
            {
                new Iteration
                {
                    IterationNo = 1,
                    Goal = "Basic Programming",
                    Courses = new List<Course>
                    {
                        new Course
                        {
                            CourseId = "C001",
                            CourseName = "C# Basics",
                            Assessments = new List<Assessment>
                            {
                                new MCQQuestion
                                {
                                    QuestionName = "What is C#?",
                                    Option1 = "A language",
                                    Option2 = "A tool",
                                    Option3 = "A framework",
                                    Option4 = "An IDE",
                                    RightOption = "A language",
                                    Marks = 5
                                },
                                new HandsOnQuestion
                                {
                                    QuestionDesc = "Create a simple C# console application",
                                    ReferenceDocument = "C# Basics.pdf",
                                    Marks = 10
                                }
                            }
                        }
                    }
                }
            }
            };

            Console.WriteLine($"Client Name: {trainingModel.ClientName}");
            Console.WriteLine($"Total Assessments: {trainingModel.GetTotalAssessmentsInTheTrainings()}");
            Console.WriteLine($"Total MCQ-Based Assessments: {trainingModel.GetNumMCQBasedAssessments()}");
            Console.WriteLine($"Total Hands-On Assessments: {trainingModel.GetNumHandsOnBasedAssessments()}");
            Console.WriteLine($"Total Score: {trainingModel.GetTotalScoreOfAllAssessments()}");
        }
    }

    public class SkillAssureTrainingModel
    {
        public string ClientName { get; set; }

        public List<Iteration> Iterations { get; set; } = new List<Iteration>();
        public int GetTotalAssessmentsInTheTrainings()
        {
            int count = 0;
            foreach (var iteration in Iterations)
            {
                foreach (var course in iteration.Courses)
                {
                    count += course.Assessments.Count;
                }
            }
            return count;
        }

        public int GetNumMCQBasedAssessments()
        {
            int count = 0;
            foreach (var iteration in Iterations)
            {
                foreach (var course in iteration.Courses)
                {
                    count += course.Assessments.FindAll(a => a is MCQQuestion).Count;
                }
            }
            return count;
        }
        public int GetNumHandsOnBasedAssessments()
        {
            int count = 0;
            foreach (var iteration in Iterations)
            {
                foreach (var course in iteration.Courses)
                {
                    count += course.Assessments.FindAll(a => a is HandsOnQuestion).Count;
                }
            }
            return count;
        }

        public int GetTotalScoreOfAllAssessments()
        {
            int totalScore = 0;
            foreach (var iteration in Iterations)
            {
                foreach (var course in iteration.Courses)
                {
                    foreach (var assessment in course.Assessments)
                    {
                        totalScore += assessment.GetTotalMarks();
                    }
                }
            }
            return totalScore;
        }
    }

    public class Iteration
    {
        public int IterationNo { get; set; }
        public string Goal { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
    public class Course
    {
       public string CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }

    public class Assessment
    {
        public int assessmentID { get; set; }
        public string assessmentDesc { get; set; }
        public DateTime dtAssesment { get; set; }

        public int NoOfQuestions { get; set; }

        public virtual int GetTotalMarks()
        {
            return 0;
        }
    }

    public abstract class Question : Assessment
    {
        public int Marks { get; set; }

        public override int GetTotalMarks()
        {
            return Marks;
        }
    }

    public class MCQQuestion : Question
    {
        public string QuestionName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string RightOption { get; set; }
    }

    public class HandsOnQuestion : Question
    {
        public string QuestionDesc { get; set; }
        public string ReferenceDocument { get; set; }
    }
}
