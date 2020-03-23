using System;
using System.Collections.Generic;

namespace SelectionCommittee.DAL.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public IEnumerable<Discipline> Disciplines { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
