using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        public string Name { get; set; }

        public int BudgetPlacesAmount { get; set; }

        public int TotalPlacesAmount { get; set; }

        public List<ClientProfile> Candidates { get; set; }
    }
}
