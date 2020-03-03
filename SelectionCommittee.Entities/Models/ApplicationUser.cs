using Microsoft.AspNet.Identity.EntityFramework;

namespace SelectionCommittee.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
