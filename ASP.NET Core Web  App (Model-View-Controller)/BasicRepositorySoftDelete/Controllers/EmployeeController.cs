using BasicRepositorySoftDelete.Models.Data;
using BasicRepositorySoftDelete.Models.DTOs;
using BasicRepositorySoftDelete.Models.ViewModel;
using BasicRepositorySoftDelete.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository _er;
        EmployeeModel _model;
        public EmployeeController(EmployeeRepository rep, EmployeeModel model)
        {
            _er = rep;
            _model = model;
        }

        public IActionResult List()
        {
            var pList = _er.Set().Select(x => new EmployeeDTO
            {
                Id = x.Id,
                EmpName = x.EmpName,
                EmpSurname = x.EmpSurname,
                CityName = x.City.CityName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false).ToList();
            return View(pList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.BtnClass = "btn btn-primary";
            _model.Title = "Create";
            _model.BtnVal = "Save";
            _model.CityList = _er.GetCityList();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            _er.Create(model.Employee);
            _er.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _model.BtnClass = "btn btn-success";
            _model.BtnVal = "Save";
            _model.Title = "Update Section";
            _model.CityList = _er.GetCityList();
            _model.Employee = _er.Find(id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            _er.Update(model.Employee);
            _er.Save();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var delEmployee = _er.Find(id);
            _er.Delete(delEmployee);
            _er.Save();
            return RedirectToAction("List");
        }
    }
}
