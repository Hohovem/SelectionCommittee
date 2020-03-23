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
    //class EnrolleeRepository : IRepository<Enrollee>
    //{
    //    private ApplicationContext db;

    //    public EnrolleeRepository(ApplicationContext context)
    //    {
    //        db = context;
    //    }

    //    public IEnumerable<Enrollee> GetAll()
    //    {
    //        return db.Enrollees;
    //    }

    //    public Enrollee Get(int id)
    //    {
    //        return db.Enrollees.Find(id);
    //    }

    //    public IEnumerable<Enrollee> Find(Func<Enrollee, bool> predicate)
    //    {
    //        //return db.Orders.Include(o => o.Phone).Where(predicate).ToList();
    //        return db.Enrollees.Where(predicate).ToList();
    //    }

    //    public void Create(Enrollee item)
    //    {
    //        db.Enrollees.Add(item);
    //    }

    //    public void Update(Enrollee item)
    //    {
    //        db.Entry(item).State = EntityState.Modified;
    //    }

    //    public void Delete(int id)
    //    {
    //        Enrollee enrollee = db.Enrollees.Find(id);
    //        if (enrollee != null)
    //            db.Enrollees.Remove(enrollee);
    //    }
    //}
}
