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
    public class TeacherController : Controller
    {
        // GET: Teacher

        SchoolContext db = new SchoolContext();

        public ActionResult List()
        {
            var tList = db.Set<Teacher>().Select(x => new TeacherDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                CityName = x.City.CityName,
                MotherName = x.MotherName
            }).ToList();

            return View(tList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TeacherModel tm = new TeacherModel();
            tm.Title = "New Entry";
            tm.BtnClass = "btn btn-primary";
            tm.BtnVal = "Add";
            tm.Type = "hidden";
            tm.Teacher = new Teacher();
            tm.CityList = GetCityList();
            return View("CrUD", tm);
        }
        [HttpPost]
        public ActionResult Create(TeacherModel tm)
        {
            db.Entry(tm.Teacher).State = EntityState.Added;
            db.SaveChanges();
            Session["Error"] = "New Entry is successful!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TeacherModel tm = new TeacherModel();
            tm.Title = "Delete Section";
            tm.BtnClass = "btn btn-danger";
            tm.BtnVal = "Delete";
            tm.Type = "hidden";
            tm.Teacher = db.Set<Teacher>().Find(id);
            tm.CityList = GetCityList();
            return View("CrUD", tm);
        }
        [HttpPost]
        public ActionResult Delete(TeacherModel tm)
        {
            try
            {
                db.Entry(tm.Teacher).State = EntityState.Deleted;
                db.SaveChanges();
                Session["Error"] = "Delete is successful!";
            }
            catch (Exception)
            {
                Session["Error"] = $"The record numbered {tm.Teacher.Id} has a connection with another record, cannot delete!";

            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            TeacherModel tm = new TeacherModel();
            tm.Title = "Update Section";
            tm.BtnClass = "btn btn-success";
            tm.BtnVal = "Save";
            tm.Type = "hidden";
            tm.Teacher = db.Set<Teacher>().Find(id);
            tm.CityList = GetCityList();
            return View("CrUD", tm);
        }
        [HttpPost]
        public ActionResult Update(TeacherModel tm)
        {
            db.Entry(tm.Teacher).State = EntityState.Modified;
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
