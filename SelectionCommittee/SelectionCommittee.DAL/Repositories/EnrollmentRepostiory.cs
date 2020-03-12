using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.DAL.EF;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    class EnrollmentRepostiory : IRepository<Enrollment>
    {
        private ApplicationContext db;

        public EnrollmentRepostiory(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return db.Enrollments;
        }

        public Enrollment Get(int id)
        {
            return db.Enrollments.Find(id);
        }

        public IEnumerable<Enrollment> Find(Func<Enrollment, bool> predicate)
        {
            //return db.Orders.Include(o => o.Phone).Where(predicate).ToList();
            return db.Enrollments.Where(predicate).ToList();
        }

        public void Create(Enrollment item)
        {
            db.Enrollments.Add(item);
        }

        public void Update(Enrollment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment != null)
                db.Enrollments.Remove(enrollment);
        }
    }
}
