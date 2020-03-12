using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EF
{
    public class EnrollmentContext : DbContext
    {
        public DbSet<Enrollee> Enrollees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        static EnrollmentContext()
        {
            Database.SetInitializer<EnrollmentContext>(new StoreDbInitializer());
        }

        public EnrollmentContext(string connectionString) : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<EnrollmentContext>
    {
        protected override void Seed(EnrollmentContext db)
        {
            //db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
            //db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
            //db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
            //db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
            //db.SaveChanges();
        }
    }
}
