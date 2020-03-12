using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectionCommittee.Web.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BudgetPlacesAmount { get; set; }

        public int TotalPlacesAmount { get; set; }
    }
}