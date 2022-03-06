using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCore.Models.Classes;
using SimpleCore.Models.Data;
using SimpleCore.Models.ViewModels;
using System.Linq;

namespace SimpleCore.Controllers
{
    public class CityController : Controller
    {
        EmpContext _db;
        CityModel _cm; //startupta ekledigimiz servis bu sekilde newleniyor.

        public CityController(EmpContext db, CityModel cm)
        {
            _db = db;
            _cm = cm; //citymodel model e atandı.

        }

        public IActionResult List()
        {
            var clist = _db.Set<City>().Include(x => x.Employees).ToList();
            return View(clist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //CityModel cm = new CityModel(); //startup yani seviste tanımlandıgı icin newlemeye ihtiyac yok

            _cm.Title = "Add New City";
            _cm.BtnClass = "btn btn-primary";
            _cm.BtnVal = "Add";

            return View("CrUD", _cm);
        }
        [HttpPost]
        public IActionResult Create(CityModel cm)
        {
            _db.Set<City>().Add(cm.City);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _cm.Title = "Delete Section";
            _cm.BtnClass = "btn btn-danger";
            _cm.BtnVal = "Delete";
            _cm.City = _db.Set<City>().Find(id);

            return View("CrUD", _cm);
        }
        [HttpPost]
        public IActionResult Delete(CityModel cm)
        {
            _db.Set<City>().Remove(cm.City);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _cm.Title = "Update Section";
            _cm.BtnClass = "btn btn-success";
            _cm.BtnVal = "Save";
            _cm.City = _db.Set<City>().Find(id);
            var c = _cm.City.Employees;

            return View("CrUD", _cm);
        }
        [HttpPost]
        public IActionResult Edit(CityModel cm)
        {
            _db.Set<City>().Update(cm.City);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
