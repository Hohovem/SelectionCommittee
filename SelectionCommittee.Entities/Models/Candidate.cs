using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.Entities.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string EducationEstablishmentName { get; set; }

        public List<Faculty> Faculties { get; set; }

    }
}
