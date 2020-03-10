using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SelectionCommittee.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string ApplicationUserId { get; set; }

        [ForeignKey("ClientProfileId")]
        public virtual int ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
