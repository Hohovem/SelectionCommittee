﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SelectionCommittee.BLL.DTO;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.Web.Models;

namespace SelectionCommittee.Web.Controllers
{
    public class FacultyController : Controller
    {
        private IEnrollmentService enrollmentService;

        public FacultyController(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        //TODO добавить поиск и пагинацию
        public ActionResult Index()
        {
            //TODO добавить поиск
            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}
            //ViewBag.CurrentFilter = searchString;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    faculties = faculties.Where(s => s.Name.Contains(searchString));
            //}
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return View();
        }

        //TODO добавить потом
        public ActionResult Register(string facultyId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FacultyDTO, FacultyViewModel>()).CreateMapper();

            //TODO сделать проверку по парсу инта
            FacultyDTO facultyDto = enrollmentService.GetFaculty(Int32.Parse(facultyId));
            FacultyViewModel facultyViewModel = mapper.Map<FacultyDTO, FacultyViewModel>(facultyDto);

            //Отрисовка интерйса по айди факультета
            //TODO другую вью модель поставить
            return View(facultyViewModel);
        }

        //TODO переделать название
        [HttpPost]
        public ActionResult Register(EnrollmentController model)
        {
            
            //Регистрация
            return View();
        }

        public ActionResult Add()
        {
            var model = new FacultyViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(FacultyViewModel model)
        {
            return View();
        }

        public ActionResult ViewAll(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BudgetPlacesSortParm = sortOrder == "Budget Places" ? "budget_places_desc" : "Budget Places";
            ViewBag.TotalPlacesSortParm = sortOrder == "Total Places" ? "total_places_desc" : "Total Places";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FacultyDTO, FacultyViewModel>()).CreateMapper();

            IEnumerable<FacultyDTO> facultyDtos = enrollmentService.GetFaculties(sortOrder);
            IEnumerable<FacultyViewModel> faculties = mapper.Map<IEnumerable<FacultyDTO>, List<FacultyViewModel>>(facultyDtos);

            return View(faculties);
        }
    }
}