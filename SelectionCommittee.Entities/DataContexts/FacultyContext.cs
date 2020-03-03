using System.Data.Entity;
using SelectionCommittee.DAL.Models;

namespace SelectionCommittee.DAL.DataContexts
{
    public class FacultyContext : DbContext
    {
        public FacultyContext() : base("FacultyDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FacultyContext>());
        }

        public DbSet<Faculty> Faculties { get; set; }
    }
}
