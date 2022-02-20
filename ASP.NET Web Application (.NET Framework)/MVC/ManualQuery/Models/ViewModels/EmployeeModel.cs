using ManualQuery.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManualQuery.Models.ViewModels
{
    public class EmployeeModel
    {
        public Employee Employee { get; set; }
        public string Title { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public List<Degree> DegreeList { get; set; }
        public List<Country> CountryList { get; set; }
        public List<Country> NatList { get; set; }
        public List<Employee> ManagerList { get; set; }
    }
}
