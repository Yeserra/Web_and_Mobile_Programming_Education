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
    public class DegreeController : Controller
    {
        // GET: Degree
        BaseRepository<Degree> dr = new BaseRepository<Degree>();
        public ActionResult List()
        {
            return View(dr.List());
        }
        [HttpGet]
        public ActionResult Create()
        {
            DegreeModel dm = new DegreeModel();
            dm.Title = "Add New Degree";
            dm.Type = "hidden";
            dm.BtnClass = "btn btn-primary";
            dm.BtnVal = "Add";
            dm.Degree = new Degree();
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Create(Degree d)
        {
            dr.Create(d, true);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(dynamic id)
        {
            DegreeModel dm = new DegreeModel();
            dm.Title = "Delete Section";
            dm.Type = "hidden";
            dm.BtnClass = "btn btn-danger";
            dm.BtnVal = "Delete";
            dm.Degree = dr.Find(id);
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Delete(Degree d)
        {
            dr.Delete(d.DegreeId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(dynamic id)
        {
            DegreeModel dm = new DegreeModel();
            dm.Title = "Update Section";
            dm.Type = "hidden";
            dm.BtnClass = "btn btn-success";
            dm.BtnVal = "Save";
            dm.Degree = dr.Find(id);
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Update(Degree d)
        {
            dr.Update(d, d.DegreeId);
            return RedirectToAction("List");
        }
    }
}
