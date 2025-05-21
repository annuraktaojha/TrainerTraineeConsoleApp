using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        //Navigation Property
        public OfficeAssignment OfficeAssignment { get; set; }
    }

    public class OfficeAssignment
    {
        public int Id { get; set; }

        public string Location { get; set; }
        public string PhoneInstruction   { get; set; }

        //navigation property
        public Instructor Instructor { get; set; }

    }
}
