using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SelectionCommittee.DAL.EF;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Identity;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private EnrollmentRepostiory _enrollmentRepostiory;
        private EnrolleeRepository _enrolleeRepository;
        private FacultyRepository _facultyRepository;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        //Main
        public IRepository<Enrollee> Enrollees => _enrolleeRepository ?? (_enrolleeRepository = new EnrolleeRepository(db));
        public IRepository<Enrollment> Enrollments => _enrollmentRepostiory ?? (_enrollmentRepostiory = new EnrollmentRepostiory(db));
        public IRepository<Faculty> Faculties => _facultyRepository ?? (_facultyRepository = new FacultyRepository(db));

        //Identity
        public ApplicationUserManager UserManager => userManager;
        public IClientManager ClientManager => clientManager;
        public ApplicationRoleManager RoleManager => roleManager;

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                //TODO перепроверить нужен ли (т.к. его тут раньше небыло)
                db.Dispose();
                userManager.Dispose();
                roleManager.Dispose();
                clientManager.Dispose();
            }
            disposed = true;
        }

        
    }
}
