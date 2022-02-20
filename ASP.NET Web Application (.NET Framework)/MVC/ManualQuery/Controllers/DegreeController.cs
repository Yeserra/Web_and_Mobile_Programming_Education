using Dapper;
using ManualQuery.Connection;
using ManualQuery.Models.Classes;
using ManualQuery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManualQuery.Controllers
{
    public class DegreeController : Controller
    {
        // GET: Degree

        SqlConnection _db = DbConnect.GetConnection();
        public ActionResult List()
        {
            string q = "select * from Degree";
            var dList = _db.Query<Degree>(q).ToList();
            return View(dList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DegreeModel d = new DegreeModel();
            d.Degree = new Degree();
            d.BtnVal = "Add";
            d.BtnClass = "btn btn-primary";
            d.Title = "Add New Degree";
            return View("CrUD", d);
        }
        [HttpPost]
        public ActionResult Create(Degree d)
        {
            string q = $"insert into Degree(DegreeName) values(@DegreeName)";
            _db.ExecuteScalar<int>(q, d);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //string q = $"select * from Degree where DegreeId = '{id}'";
            //var d = _db.Query<Degree>(q).First();
            //return View(d);
            DegreeModel d = new DegreeModel();
            string q = $"select * from Degree where DegreeId = '{id}'";
            //var d = _db.Query<Degree>(q).First();
            d.Degree = _db.Query<Degree>(q).First();
            d.BtnVal = "Delete";
            d.BtnClass = "btn btn-danger";
            d.Title = "Delete Section";
            return View("CrUD", d);

        }
        [HttpPost]
        public ActionResult Delete(Degree d)
        {
            //string q = $"delete from Degree where DegreeId = @DegreeId";
            //_db.ExecuteScalar<int>(q, d);
            //return RedirectToAction("List");
            string q = $"delete from Degree where DegreeId = @DegreeId";
            DynamicParameters par = new DynamicParameters();
            par.Add("@DegreeName", d.DegreeName);
            par.Add("@DegreeId", d.DegreeId);
            var num = _db.ExecuteScalar<int>(q, par);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            DegreeModel d = new DegreeModel();
            string q = $"select * from Degree where DegreeId = '{id}'";
            //var d = _db.Query<Degree>(q).First();
            d.Degree = _db.Query<Degree>(q).First();
            d.BtnVal = "Save";
            d.BtnClass = "btn btn-success";
            d.Title = "Update Section";
            return View("CrUD", d);
        }
        [HttpPost]
        public ActionResult Update(Degree d)
        {
            string q = $"update Degree set DegreeName = @DegreeName where DegreeId = @DegreeId";
            DynamicParameters par = new DynamicParameters();
            par.Add("@DegreeName", d.DegreeName);
            par.Add("@DegreeId", d.DegreeId);
            var num = _db.ExecuteScalar<int>(q, par);
            return RedirectToAction("List");
        }
    }
}
