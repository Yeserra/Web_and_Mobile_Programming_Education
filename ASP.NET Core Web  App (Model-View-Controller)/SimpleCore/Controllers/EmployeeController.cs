using Microsoft.AspNetCore.Mvc;
using SimpleCore.Models.Classes;
using SimpleCore.Models.Data;
using SimpleCore.Models.DTOs;
using SimpleCore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCore.Controllers
{
    public class EmployeeController : Controller
    {
        EmpContext _db;
        EmployeeModel _em;

        public EmployeeController(EmpContext db, EmployeeModel em)
        {
            _db = db;
            _em = em;
        }

        public IActionResult List()
        {
            var eList = _db.Set<Employee>().Select(x => new EmployeeDTO
            {
                Id = x.EmployeeId,
                Name = x.Name,
                Surname = x.Surname,
                CityName = x.City.CityName,

            }).ToList();
            return View(eList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            _em.BtnClass = "btn btn-primary";
            _em.BtnVal = "Add";
            _em.Title = "Add New Employee";
            _em.CityList = GetCityList();
            return View("CrUD", _em);
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel em)
        {
            _db.Set<Employee>().Add(em.Employee);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _em.BtnClass = "btn btn-danger";
            _em.BtnVal = "Delete";
            _em.Title = "Delete Section";
            _em.Employee = _db.Set<Employee>().Find(id);
            _em.CityList = GetCityList();
            return View("CrUD", _em);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeModel em)
        {
            _db.Set<Employee>().Remove(em.Employee);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _em.BtnClass = "btn btn-success";
            _em.BtnVal = "Save";
            _em.Title = "Update Section";
            _em.Employee = _db.Set<Employee>().Find(id);
            _em.CityList = GetCityList();
            return View("CrUD", _em);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel em)
        {
            _db.Set<Employee>().Update(em.Employee);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        private List<City> GetCityList()
        {
            return _db.Set<City>().Select(x => new City
            {
                CityId = x.CityId,
                CityName = x.CityName
            }).ToList();
        }
    }
}
