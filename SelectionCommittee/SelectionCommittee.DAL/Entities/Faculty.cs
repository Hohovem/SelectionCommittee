using System.Collections.Generic;

namespace SelectionCommittee.DAL.Entities
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int BudgetPlacesAmount { get; set; }
        public int TotalPlacesAmount { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
