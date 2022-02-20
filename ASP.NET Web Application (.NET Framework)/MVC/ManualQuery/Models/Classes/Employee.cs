using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManualQuery.Models.Classes
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public int DegreeId { get; set; }
        public string CountryId { get; set; }
        public string NatId { get; set; }
        public int ManagerId { get; set; }
    }
}
