using Framework;
using Project.Models.Classes;
using Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        BaseRepository<Country> cr = new BaseRepository<Country>();
        public ActionResult List()
        {
            return View(cr.List());
        }
        [HttpGet]
        public ActionResult Create()
        {
            CountryModel cm = new CountryModel();
            cm.Title = "Add New Country";
            cm.Type = "text";
            cm.BtnClass = "btn btn-primary";
            cm.BtnVal = "Add";
            cm.Country = new Country();
            return View("CrUD", cm);
        }
        [HttpPost]
        public ActionResult Create(Country c)
        {
            cr.Create(c, false);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            CountryModel c = new CountryModel();
            c.Title = "Delete Section";
            c.Type = "hidden";
            c.BtnClass = "btn btn-danger";
            c.BtnVal = "Delete";
            c.Country = cr.Find(id);
            return View("CrUD", c);
        }
        [HttpPost]
        public ActionResult Delete(Country c)
        {
            cr.Delete(c.CountryId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            CountryModel c = new CountryModel();
            c.Title = "Update Section";
            c.Type = "hidden";
            c.BtnClass = "btn btn-success";
            c.BtnVal = "Save";
            c.Country = cr.Find(id);
            return View("CrUD", c);
        }
        [HttpPost]
        public ActionResult Update(Country c)
        {
            cr.Update(c, c.CountryId);
            return RedirectToAction("List");
        }
    }
}
