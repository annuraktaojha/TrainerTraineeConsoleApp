using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
