using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.Entities.Models;

namespace SelectionCommittee.Entities.DataContexts
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
