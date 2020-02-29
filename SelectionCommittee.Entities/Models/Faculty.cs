using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.Entities.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        public string Name { get; set; }

        public int BudgetPlacesAmount { get; set; }

        public int TotalPlacesAmount { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
