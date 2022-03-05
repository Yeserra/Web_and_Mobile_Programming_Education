using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel_EF.Models.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string Nationality { get; set; }
        public string Manager { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
