using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelectionCommittee.Web.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Faculty Name")]
        public string Name { get; set; }

        [Display(Name = "Budget places amount")]
        public int BudgetPlacesAmount { get; set; }

        [Display(Name = "Total places amount")]
        public int TotalPlacesAmount { get; set; }

        //TODO переделать строку в отдельный класс
        public IEnumerable<string> Disciplines { get; set; }
    }
}