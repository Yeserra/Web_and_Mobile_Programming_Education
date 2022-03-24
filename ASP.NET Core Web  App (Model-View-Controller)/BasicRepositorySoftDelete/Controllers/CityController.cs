using BasicRepositorySoftDelete.Models.Data;
using BasicRepositorySoftDelete.Models.ViewModel;
using BasicRepositorySoftDelete.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Controllers
{
    public class CityController : Controller
    {
        CityRepository _cr;
        CityModel _model;
        public CityController(CityRepository rep, CityModel model)
        {
            _cr = rep;
            _model = model;
        }

        public IActionResult List()
        {
            var x = _cr.List();
            return View(x);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.BtnClass = "btn btn-primary";
            _model.Title = "Create";
            _model.BtnVal = "Save";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            _cr.Create(model.City);
            _cr.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _model.BtnClass = "btn btn-success";
            _model.BtnVal = "Save";
            _model.Title = "Update Section";
            _model.City = _cr.Find(id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(CityModel model)
        {
            _cr.Update(model.City);
            _cr.Save();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var delCity = _cr.Find(id);
            _cr.Delete(delCity);
            _cr.Save();
            return RedirectToAction("List");
        }
    }
}
