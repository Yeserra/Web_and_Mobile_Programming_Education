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
    public class DegreeController : Controller
    {
        // GET: Degree

        empDBEntities db = new empDBEntities();

        public ActionResult List()
        {
            //var dList = db.Degree.ToList(); /* 1.YÖNTEM */
            var dList = db.Set<Degree>().ToList();
            return View(dList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Session["Error"] = "";
            DegreeModel dm = new DegreeModel();
            dm.Title = "Add New Degree";
            dm.BtnClass = "btn btn-primary";
            dm.BtnVal = "Add";
            dm.Type = "hidden";
            dm.Degree = new Degree();
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Create(Degree d)
        {
            // db.Degree.Add(d); /* 1.YOL */
            // db.Set<Degree>().Add(d);  /* 2.YOL */
            db.Entry(d).State = EntityState.Added;  /* 3.YOL */
            db.SaveChanges();
            Session["Error"] = "Registration successfully added.";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Session["Error"] = "";
            DegreeModel dm = new DegreeModel();
            dm.Title = "Delete Section";
            dm.BtnClass = "btn btn-danger";
            dm.BtnVal = "Delete";
            dm.Type = "hidden";
            dm.Degree = db.Set<Degree>().Find(id);
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Delete(Degree d)
        {
            // db.Degree.Remove(d);  /* 1.YOL */
            // db.Set<Degree>().Remove(d);   /* 2.YOL */
            try
            {
                Session["cls"] = "light";
                db.Entry(d).State = EntityState.Deleted;    /* 3.YOL */
                db.SaveChanges();
                Session["Error"] = $"The record has deleted successfully.";
            }
            catch (Exception ex)
            {
                //ViewBag.Error = ex.Message;
                Session["Error"] = $"The record numbered {d.DegreeId} has a connection, cannot be deleted!";
                Session["cls"] = "danger";
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Session["Error"] = "";
            DegreeModel dm = new DegreeModel();
            dm.Title = "Update Section";
            dm.BtnClass = "btn btn-success";
            dm.BtnVal = "Save";
            dm.Type = "hidden";
            dm.Degree = db.Set<Degree>().Find(id);
            return View("CrUD", dm);
        }
        [HttpPost]
        public ActionResult Update(Degree d)
        {
            // db.Degree.Remove(d);  /* 1.YOL */
            // db.Set<Degree>().Remove(d);   /* 2.YOL */
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();
            Session["Error"] = "The record has updated successfully.";
            Session["cls"] = "success";
            return RedirectToAction("List");
        }
    }
}
