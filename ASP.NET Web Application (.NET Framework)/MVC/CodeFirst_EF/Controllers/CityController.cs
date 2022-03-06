using CodeFirst_EF.Models.Data;
using CodeFirst_EF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_EF.Controllers
{
    public class CityController : Controller
    {
        // GET: City

        SchoolContext db = new SchoolContext();

        public ActionResult List()
        {
            var cList = db.Set<City>().ToList();
            return View(cList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Session["Error"] = "";
            CityModel cm = new CityModel();
            cm.Title = "Entry Section";
            cm.BtnClass = "btn btn-primary";
            cm.BtnVal = "Add";
            cm.Type = "hidden";
            cm.City = new City();
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Create(City c)
        {
            db.Entry(c).State = EntityState.Added;
            db.SaveChanges();
            Session["Error"] = "New Entry is successful!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Session["Error"] = "";
            CityModel cm = new CityModel();
            cm.Title = "Delete Section";
            cm.BtnClass = "btn btn-danger";
            cm.BtnVal = "Delete";
            cm.Type = "hidden";
            cm.City = db.Set<City>().Find(id);
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Delete(City c)
        {
            try
            {
                Session["Error"] = "";
                Session["cls"] = "light";
                db.Entry(c).State = EntityState.Deleted;
                Session["Error"] = "The Record has deleted successfully!";
                db.SaveChanges();
            }
            catch (Exception)
            {
                Session["Error"] = $"The record numbered {c.CityId} has a connection with another record, cannot delete!";
                Session["cls"] = "danger";
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Session["Error"] = "";
            CityModel cm = new CityModel();
            cm.Title = "Update Section";
            cm.BtnClass = "btn btn-success";
            cm.BtnVal = "Save";
            cm.Type = "hidden";
            cm.City = db.Set<City>().Find(id);
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Update(City c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            Session["Error"] = "The record has upgraded successfully!";
            Session["cls"] = "success";
            return RedirectToAction("List");
        }
    }
}
