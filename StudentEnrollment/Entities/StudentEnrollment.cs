using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Entities
{
    public class StudentEnrollment
    {
        public int EnrollmentId { get; set; }


        public DateTime EnrollmentDate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
        [Range(1, 100)]
        public decimal? Grade { get; set; }
    }


}
