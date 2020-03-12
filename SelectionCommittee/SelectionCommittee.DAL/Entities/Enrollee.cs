using System.Collections;

namespace SelectionCommittee.DAL.Entities
{
    public class Enrollee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Town { get; set; }
        public string Region { get; set; }
        public string EducationEstablishmentName { get; set; }

        public ICollection Enrollments { get; set; }
    }
}
