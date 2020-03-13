using Ninject.Modules;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

namespace SelectionCommittee.BLL.Infrastructure
{
    public class EnrollmentModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEnrollmentService>().To<EnrollmentService>();
        }
    }
}