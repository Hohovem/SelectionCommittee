using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Repositories;

namespace SelectionCommittee.BLL.Services
{
    /// <summary>
    /// Создание сервисов через овин
    /// </summary>
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}
