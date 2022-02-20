using Dapper;
using ManualQuery.Connection;
using ManualQuery.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManualQuery.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country

        SqlConnection _db = DbConnect.GetConnection();
        public ActionResult List()
        {
            string q = "select * from Country";
            var cList = _db.Query<Country>(q).ToList();
            return View(cList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Country c = new Country();
            return View(c);
        }
        [HttpPost]
        public ActionResult Create(Country c)
        {
            string q = $"insert into Country (CountryId, CountryName) values(@CountryId, @CountryName)";
            _db.ExecuteScalar<int>(q, c);
            return RedirectToAction("List");
        }

        //SİLME İŞLEMİ 1.YOL:
        /*
        [HttpGet]
        public ActionResult Delete(string id)
        {
            string q = $"Delete from Country where CountryId = '{id}'";
            var Country = _db.ExecuteScalar<int>(q);
            return RedirectToAction("List");
        }*/

        //SİLME İŞLEMİ 2.YOL:
        [HttpGet]
        public ActionResult Delete(string id)
        {
            string q = $"select * from Country where CountryId = '{id}'";
            var c = _db.Query<Country>(q).First();
            return View(c);
        }
        [HttpPost]
        public ActionResult Delete(Country c)
        {
            string q = $"delete from Country where CountryId = @CountryId";
            _db.ExecuteScalar<int>(q, c);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            string q = $"select * from Country where CountryId = '{id}'";
            var c = _db.Query<Country>(q).First();
            return View(c);
        }
        [HttpPost]
        public ActionResult Update(Country c)
        {
            string q = $"update Country set CountryName = @CountryName where CountryId = @CountryId";

            //1.YOL
            //var Country = _db.ExecuteScalar<int>(q, c);

            //2.YOL
            DynamicParameters par = new DynamicParameters();
            par.Add("@CountryName", c.CountryName);
            par.Add("@CountryId", c.CountryId);
            var num = _db.ExecuteScalar<int>(q, par);
            return RedirectToAction("List");
        }
    }
}
