using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Entities
{
    // modified the class to Abstract as mapped tpc
    public  class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }

    public class OnlineCourse:Course
    {
        public string Url { get; set; }
    }

    public class OnsiteCourse : Course
    {
        public string Address { get; set; }
    }
}
