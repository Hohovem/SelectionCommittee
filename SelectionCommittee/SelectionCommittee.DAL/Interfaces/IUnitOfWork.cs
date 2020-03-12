using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Identity;

namespace SelectionCommittee.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Identity block
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();

        //Custom block
        IRepository<Enrollee> Enrollees { get; }
        IRepository<Enrollment> Enrollments { get; }
        IRepository<Faculty> Faculties { get; }
        void Save();
    }
}
