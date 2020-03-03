using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Models
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public int Id { get; set; }
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
