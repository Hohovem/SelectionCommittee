using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SelectionCommittee.BLL.BusinessModels;
using SelectionCommittee.BLL.DTO;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.DAL.Entities;
using SelectionCommittee.DAL.Interfaces;

namespace SelectionCommittee.BLL.Services
{
    /// <summary>
    /// Сервис отвечающий за факультеты и операции с ними
    /// </summary>
    public class EnrollmentService : IEnrollmentService
    {
        IUnitOfWork Database { get; }

        public EnrollmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool MakeRegister(EnrollmentDTO enrollmentDto)
        {
            //TODO перезаполнить правильно
            return false;
        }

        public IEnumerable<FacultyDTO> GetFaculties()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Faculty, FacultyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Faculty>, List<FacultyDTO>>(Database.Faculties.GetAll());
        }

        public IEnumerable<FacultyDTO> GetFaculties(string sortOrder)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Faculty, FacultyDTO>()).CreateMapper();
            var faculties = mapper.Map<IEnumerable<Faculty>, List<FacultyDTO>>(Database.Faculties.GetAll());

            IEnumerable<FacultyDTO> sortedFaculties;

            switch (sortOrder)
            {
                case "name_desc":
                    sortedFaculties = faculties.OrderByDescending(s => s.Name);
                    break;
                case "Budget Places":
                    sortedFaculties = faculties.OrderBy(s => s.BudgetPlacesAmount);
                    break;
                case "free_places_desc":
                    sortedFaculties = faculties.OrderByDescending(s => s.BudgetPlacesAmount);
                    break;
                case "Total Places":
                    sortedFaculties = faculties.OrderBy(s => s.TotalPlacesAmount);
                    break;
                case "total_places_desc":
                    sortedFaculties = faculties.OrderByDescending(s => s.TotalPlacesAmount);
                    break;
                default:  // Name ascending 
                    sortedFaculties = faculties.OrderBy(s => s.Name);
                    break;
            }

            return sortedFaculties;
        }

        public FacultyDTO GetFaculty(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id факультета", "");
            var faculty = Database.Faculties.Get(id.Value);
            if (faculty == null)
                throw new ValidationException("Факультет не найден", "");
            
            return new FacultyDTO
            {
                //TODO добавить автомаппер?
                Name = faculty.Name,
                BudgetPlacesAmount = faculty.BudgetPlacesAmount,
                TotalPlacesAmount = faculty.TotalPlacesAmount,
                Id = faculty.Id
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
