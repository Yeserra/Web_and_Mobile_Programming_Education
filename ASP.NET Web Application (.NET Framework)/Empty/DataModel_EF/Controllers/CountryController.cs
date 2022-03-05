using DataModel_EF.Models.Data;
using DataModel_EF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataModel_EF.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country

        empDBEntities db = new empDBEntities();

        public ActionResult List()
        {
            var cList = db.Set<Country>().ToList();
            return View(cList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Session["Error"] = "";
            CountryModel cm = new CountryModel();
            cm.Title = "Add New Country";
            cm.BtnClass = "btn btn-primary";
            cm.BtnVal = "Add";
            cm.Type = "text";
            cm.Country = new Country();
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Create(Country c)
        {
            db.Entry(c).State = EntityState.Added;
            db.SaveChanges();
            Session["Error"] = "Registration successfully added.";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Session["Error"] = "";
            CountryModel cm = new CountryModel();
            cm.Title = "Delete Section";
            cm.BtnClass = "btn btn-danger";
            cm.BtnVal = "Delete";
            cm.Type = "hidden";
            cm.Country = db.Set<Country>().Find(id);
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Delete(Country c)
        {
            try
            {
                Session["cls"] = "light";
                db.Entry(c).State = EntityState.Deleted;
                db.SaveChanges();
                Session["Error"] = $"The record has deleted successfully.";
            }
            catch
            {
                Session["Error"] = $"The record numbered {c.CountryId} has a connection, cannot be deleted!";
                Session["cls"] = "danger";
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            Session["Error"] = "";
            CountryModel cm = new CountryModel();
            cm.Title = "Update Section";
            cm.BtnClass = "btn btn-success";
            cm.BtnVal = "Save";
            cm.Type = "hidden";
            cm.Country = db.Set<Country>().Find(id);
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Update(Country c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            Session["Error"] = "The record has updated successfully.";
            Session["cls"] = "success";
            return RedirectToAction("List");
        }
    }
}
