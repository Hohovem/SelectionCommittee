using System;

namespace SelectionCommittee.DAL.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int Id { get; set; }
        public Grade? Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int EnrolleeId { get; set; }
        public Enrollee Enrollee { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
