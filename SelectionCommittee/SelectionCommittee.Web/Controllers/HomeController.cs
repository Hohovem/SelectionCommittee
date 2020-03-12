using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.BLL.DTO;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.Web.Models;

namespace SelectionCommittee.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEnrollmentService enrollmentService;

        public HomeController(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        public ActionResult Index()
        {
            //IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>()).CreateMapper();
            //var phones = mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
            //return View(phones);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MakeEnrollment(int? id)
        {
            try
            {
                FacultyDTO facultyDtos = enrollmentService.GetFaculty(id);
                var enrollment = new EnrollmentViewModel() {  };

                return View(enrollment);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeEnrollment(EnrollmentViewModel order)
        {
            try
            {
                var enrollmentDto = new EnrollmentDTO() { /*PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber*/ };
                enrollmentService.MakeOrder(enrollmentDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            enrollmentService.Dispose();
            base.Dispose(disposing);
        }
    }
}