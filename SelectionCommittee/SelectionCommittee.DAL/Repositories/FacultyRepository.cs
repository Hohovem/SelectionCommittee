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
    class FacultyRepository : IRepository<Faculty>
    {
        private ApplicationContext db;

        public FacultyRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Faculty> GetAll()
        {
            return db.Faculties;
        }

        public Faculty Get(int id)
        {
            return db.Faculties.Find(id);
        }

        public IEnumerable<Faculty> Find(Func<Faculty, bool> predicate)
        {
            return db.Faculties.Where(predicate).ToList();
        }

        public void Create(Faculty item)
        {
            db.Faculties.Add(item);
        }

        public void Update(Faculty item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Faculty faculty = db.Faculties.Find(id);

            if (faculty != null)
                db.Faculties.Remove(faculty);
        }
    }
}
