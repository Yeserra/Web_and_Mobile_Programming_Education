using Dapper;
using ManualQuery.Connection;
using ManualQuery.DTOs;
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
    public class EmployeeController : Controller
    {
        // GET: Employee

        SqlConnection _db = DbConnect.GetConnection();
        public ActionResult List()
        {
            string q = "select e.EmployeeId, e.Name + ' ' + e.Surname Name_Surname, c.CountryName Residence, n.CountryName Nationality, isnull(m.Name + ' ' + m.Surname, 'Manager')Manager from Employee e inner join Country c on (c.CountryId = e.CountryId) inner join Country n on (n.CountryId = e.NatId) left outer join Employee m on (m.EmployeeId = e.ManagerId)";
            var eList = _db.Query<EmployeeDTO>(q).ToList();
            return View(eList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmployeeModel e = new EmployeeModel();
            e.Title = "Add New Employee";
            e.BtnVal = "Add";
            e.BtnClass = "btn btn-primary";
            e.Employee = new Employee();
            e.DegreeList = GetDegreeList();
            e.CountryList = GetCountryList();
            e.NatList = GetCountryList();
            e.ManagerList = GetManagerList();
            return View("CrUD", e);
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel e)
        {
            string q = $"insert into Employee(Name, Surname, Salary, DegreeId, CountryId, NatId, ManagerId) values(@Name, @Surname, @Salary, @DegreeId, @CountryId, @NatId, @ManagerId)";
            _db.ExecuteScalar<int>(q, e.Employee);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeModel e = new EmployeeModel();
            e.Title = "Delete Section";
            e.BtnVal = "Delete";
            e.BtnClass = "btn btn-danger";
            e.Employee = GetEmployee(id);
            e.DegreeList = GetDegreeList();
            e.CountryList = GetCountryList();
            e.NatList = GetCountryList();
            e.ManagerList = GetManagerList();
            return View("CrUD", e);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeModel e)
        {
            string q = $"delete from Employee where EmployeeId = @EmployeeId";
            _db.ExecuteScalar<int>(q, e.Employee);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            EmployeeModel e = new EmployeeModel();
            e.Title = "Update Section";
            e.BtnClass = "btn btn-success";
            e.BtnVal = "Save";
            e.Employee = GetEmployee(id);
            e.DegreeList = GetDegreeList();
            e.CountryList = GetCountryList();
            e.NatList = GetCountryList();
            e.ManagerList = GetManagerList();
            return View("Crud", e);
        }
        [HttpPost]
        public ActionResult Update(EmployeeModel e)
        {
            string q = $"Update Employee set Name = @Name, Surname = @Surname, Salary = @Salary, DegreeId = @DegreeId, CountryId = @CountryId, NatId = @NatId, ManagerId = @ManagerId where EmployeeId = @EmployeeId";
            _db.ExecuteScalar<int>(q, e.Employee);
            return RedirectToAction("List");
        }

        private List<Employee> GetManagerList()
        {
            string q = "select * from Employee";
            return _db.Query<Employee>(q).ToList();
        }

        private List<Country> GetCountryList()
        {
            string q = "select * from Country";
            return _db.Query<Country>(q).ToList();
        }

        private List<Degree> GetDegreeList()
        {
            string q = "select * from Degree";
            return _db.Query<Degree>(q).ToList();
        }

        private Employee GetEmployee(int id)
        {
            string q = $"Select * from Employee where EmployeeId = '{id}'";
            return _db.Query<Employee>(q).First();
        }
    }
}
