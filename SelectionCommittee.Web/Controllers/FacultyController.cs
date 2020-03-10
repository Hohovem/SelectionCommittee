using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SelectionCommittee.DAL.DataContexts;

namespace SelectionCommittee.Web.Controllers
{
    public class FacultyController : Controller
    {
        FacultyContext con = new FacultyContext();

        // GET: Faculty
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FreePlacesSortParm = sortOrder == "Free Places" ? "free_places_desc" : "Free Places";
            ViewBag.TotalPlacesSortParm = sortOrder == "Total Places" ? "total_places_desc" : "Total Places";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var faculties = from s in con.Faculties
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                faculties = faculties.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    faculties = faculties.OrderByDescending(s => s.Name);
                    break;
                case "Free Places":
                    faculties = faculties.OrderBy(s => s.FreePlacesAmount);
                    break;
                case "free_places_desc":
                    faculties = faculties.OrderByDescending(s => s.FreePlacesAmount);
                    break;
                case "Total Places":
                    faculties = faculties.OrderBy(s => s.TotalPlacesAmount);
                    break;
                case "total_places_desc":
                    faculties = faculties.OrderByDescending(s => s.TotalPlacesAmount);
                    break;
                default:  // Name ascending 
                    faculties = faculties.OrderBy(s => s.Name);
                    break;
            }

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            return View(faculties);
        }

        //// GET: Faculty/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Faculty/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Faculty/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Faculty/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Faculty/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Faculty/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Faculty/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
