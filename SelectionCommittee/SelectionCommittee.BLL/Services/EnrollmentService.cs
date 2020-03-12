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
    public class EnrollmentService : IEnrollmentService
    {
        IUnitOfWork Database { get; set; }

        public EnrollmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(EnrollmentDTO enrollmentDto)
        {
            //TODO перезаполнить правильно
            //Faculty phone = Database.Faculties.Get(enrollmentDto.PhoneId);

            //// валидация
            //if (phone == null)
            //    throw new ValidationException("Телефон не найден", "");

            //// применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);

            //Enrollment enrollmentder = new Enrollment()
            //{
            //    EnrollmentDate = DateTime.Now,
            //    //Address = orderDto.Address,
            //    //PhoneId = phone.Id,
            //    //Sum = sum,
            //    //PhoneNumber = orderDto.PhoneNumber
            //};
            //Database.Orders.Create(order);
            //Database.Save();
        }

        public IEnumerable<FacultyDTO> GetFaculties()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Faculty, FacultyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Faculty>, List<FacultyDTO>>(Database.Faculties.GetAll());
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
                //TODO проверить инициализацию
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
