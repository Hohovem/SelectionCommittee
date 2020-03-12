using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.DAL.EF;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
