using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionCommittee.BLL.DTO;

namespace SelectionCommittee.BLL.Interfaces
{
    //TODO фейк или нет
    public interface IEnrollmentService
    {
        bool MakeRegister(EnrollmentDTO enrollmentDto);
        FacultyDTO GetFaculty(int? id);
        IEnumerable<FacultyDTO> GetFaculties();
        IEnumerable<FacultyDTO> GetFaculties(string sortOrder);
        void Dispose();
    }
}
