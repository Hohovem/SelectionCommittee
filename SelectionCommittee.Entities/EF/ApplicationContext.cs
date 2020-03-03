using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.Models;

namespace SelectionCommittee.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {      
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
