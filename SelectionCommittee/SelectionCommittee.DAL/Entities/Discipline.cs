using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.DAL.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Grade? Grade { get; set; }
    }
}
