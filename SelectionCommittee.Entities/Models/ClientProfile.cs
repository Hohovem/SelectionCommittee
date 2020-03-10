using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Models
{
    public class ClientProfile
    {
        [Key]
        public int ClientProfileId { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display( Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [EmailAddress]
        [Display(Name = "Your Email Address")]
        public string Email { get; set; }
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Display(Name = "Region")]
        public string Region { get; set; }
        [Display(Name = "Education Establishment Name")]
        public string EducationEstablishmentName { get; set; }

        public List<Faculty> Faculties { get; set; }

    }
}
