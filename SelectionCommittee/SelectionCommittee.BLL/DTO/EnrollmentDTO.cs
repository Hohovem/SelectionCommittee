using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionCommittee.BLL.DTO
{
    public class EnrollmentDTO
    {
        #region EntitiesID
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FacultyId { get; set; }
        #endregion

        //public IEnumerable<Discipline> Disciplines { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int ApplicationUserId { get; set; }
    }
}
