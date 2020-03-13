using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.BLL.DTO
{
    public class FacultyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BudgetPlacesAmount { get; set; }

        public int TotalPlacesAmount { get; set; }
    }
}
