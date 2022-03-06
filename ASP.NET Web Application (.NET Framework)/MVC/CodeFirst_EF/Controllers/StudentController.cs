using CodeFirst_EF.Models.Data;
using CodeFirst_EF.Models.DTOs;
using CodeFirst_EF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_EF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        SchoolContext db = new SchoolContext();

        public ActionResult List()
        {
            var sList = db.Set<Student>().Select(x => new StudentDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                CityName = x.City.CityName,
                MotherName = x.MotherName
            }).ToList();

            return View(sList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            StudentModel sm = new StudentModel();
            sm.Title = "New Entry";
            sm.BtnClass = "btn btn-primary";
            sm.BtnVal = "Add";
            sm.Type = "hidden";
            sm.Student = new Student();
            sm.CityList = GetCityList();
            return View("CrUD", sm);
        }
        [HttpPost]
        public ActionResult Create(StudentModel sm)
        {
            db.Entry(sm.Student).State = EntityState.Added;
            db.SaveChanges();
            Session["Error"] = "New Entry is successful!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentModel sm = new StudentModel();
            sm.Title = "Delete Section";
            sm.BtnClass = "btn btn-danger";
            sm.BtnVal = "Delete";
            sm.Type = "hidden";
            sm.Student = db.Set<Student>().Find(id);
            sm.CityList = GetCityList();
            return View("CrUD", sm);
        }
        [HttpPost]
        public ActionResult Delete(StudentModel sm)
        {
            try
            {
                Session["Error"] = null;
                db.Entry(sm.Student).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception)
            {
                Session["Error"] = $"The record numbered {sm.Student.Id} has a connection with another record, cannot delete!";

            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            StudentModel sm = new StudentModel();
            sm.Title = "Update Section";
            sm.BtnClass = "btn btn-success";
            sm.BtnVal = "Save";
            sm.Type = "hidden";
            sm.Student = db.Set<Student>().Find(id);
            sm.CityList = GetCityList();
            return View("CrUD", sm);
        }
        [HttpPost]
        public ActionResult Update(StudentModel sm)
        {
            db.Entry(sm.Student).State = EntityState.Modified;
            db.SaveChanges();
            Session["Error"] = "Update is successful!";
            return RedirectToAction("List");
        }

        private List<CityDTO> GetCityList()
        {
            return db.Set<City>().Select(x => new CityDTO
            {
                CityId = x.CityId,
                CityName = x.CityName
            }).ToList();
        }
    }
}
