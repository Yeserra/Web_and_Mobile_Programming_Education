using DataModel_EF.Models.Data;
using DataModel_EF.Models.DTOs;
using DataModel_EF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataModel_EF.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        empDBEntities db = new empDBEntities();

        public ActionResult List()
        {
            var elist = db.Set<Employee>().Select(x => new EmployeeDTO
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                Surname = x.Surname,
                DegreeId = (int)(x.DegreeId),
                DegreeName = x.Degree.DegreeName,
                Nationality = x.Country.CountryName,
                Manager = x.Employee2.Name + " " + x.Employee2.Surname
            }).ToList();

            return View(elist);
        }

        public ActionResult ListByDegreeId(int id)
        {
            var eList = db.Set<Employee>().Select(x => new EmployeeDTO
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                Surname = x.Surname,
                DegreeId = (int)(x.DegreeId),
                DegreeName = x.Degree.DegreeName,
                Nationality = x.Country.CountryName,
                Manager = x.Employee2.Name + " " + x.Employee2.Surname
            }).Where(x => x.DegreeId == id).ToList();

            return View("List", eList);
        }

        public ActionResult ListByCountryId(string id)
        {
            var eList = db.Set<Employee>().Select(x => new EmployeeDTO
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                Surname = x.Surname,
                CountryId = (string)(x.CountryId),
                CountryName = x.Country.CountryName,
                Nationality = x.Country.CountryName,
                Manager = x.Employee2.Name + " " + x.Employee2.Surname
            }).Where(x => x.CountryId == id).ToList();

            return View("List", eList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmployeeModel em = new EmployeeModel();
            em.Title = "Add New Employee";
            em.BtnClass = "btn btn-primary";
            em.BtnVal = "Add";
            em.Type = "hidden";
            em.Employee = new Employee();
            em.CountryList = GetCountryList();
            em.DegreeList = GetDegreeList();
            em.ManagerList = GetManagerList();
            return View("CrUD", em);
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel em)
        {
            db.Entry(em.Employee).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeModel em = new EmployeeModel();
            em.Title = "Delete Section";
            em.BtnClass = "btn btn-danger";
            em.BtnVal = "Delete";
            em.Type = "hidden";
            em.Employee = db.Set<Employee>().Find(id);
            em.CountryList = GetCountryList();
            em.DegreeList = GetDegreeList();
            em.ManagerList = GetManagerList();
            return View("CrUD", em);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeModel em)
        {
            //1.yol
            //db.Degree.Remove(em);

            //2.yol
            //db.Set<Degree>().Remove(em);

            try
            {
                //3.yol
                Session["Error"] = null;
                db.Entry(em.Employee).State = EntityState.Deleted;
                db.SaveChanges(); // her 3 yoldada savechanges yapılması gerekir.


            }
            catch (Exception)
            {
                //ViewBag.Error = ex.Message; 1.yol
                Session["Error"] = "This record has a connection. It cannot delete!";

            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            EmployeeModel em = new EmployeeModel();
            em.Title = "Update Section";
            em.BtnClass = "btn btn-success";
            em.BtnVal = "Save";
            em.Type = "hidden";
            em.Employee = db.Set<Employee>().Find(id);
            em.CountryList = GetCountryList();
            em.DegreeList = GetDegreeList();
            em.ManagerList = GetManagerList();
            return View("CrUD", em);
        }
        [HttpPost]
        public ActionResult Update(EmployeeModel em)
        {
            db.Entry(em.Employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        private List<CountryDTO> GetCountryList()
        {
            return db.Set<Country>().Select(x => new CountryDTO
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName
            }).ToList();
        }

        private List<DegreeDTO> GetDegreeList()
        {
            return db.Set<Degree>().Select(x => new DegreeDTO
            {
                DegreeId = x.DegreeId,
                DegreeName = x.DegreeName
            }).ToList();
        }

        private List<ManagerDTO> GetManagerList()
        {
            return db.Set<Employee>().Select(x => new ManagerDTO
            {
                ManagerId = x.ManagerId ?? 0,
                FullName = x.Employee2.Name + " " + x.Employee2.Surname
            }).Distinct().ToList(); //Distinct metodu tekrarlamayı engeller.
        }
    }
}
