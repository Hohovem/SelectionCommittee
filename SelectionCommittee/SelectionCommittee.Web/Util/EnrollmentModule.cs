using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Ninject.Modules;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

namespace SelectionCommittee.Web.Util
{
    public class EnrollmentModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEnrollmentService>().To<EnrollmentService>();
        }
    }
}