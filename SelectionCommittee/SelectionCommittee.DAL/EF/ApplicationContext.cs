using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Enrollee> Enrollees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public ApplicationContext(string conectionString) : base(conectionString)
        {
            //TODO Заходит но не дропает
            //Database.SetInitializer(new StoreDbInitializer());
        }

        public ApplicationContext()
        {
            //Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
        {
            protected override void Seed(ApplicationContext db)
            {
                //db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
                //db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
                //db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
                //db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
                //db.SaveChanges();
            }
        }
    }
}
