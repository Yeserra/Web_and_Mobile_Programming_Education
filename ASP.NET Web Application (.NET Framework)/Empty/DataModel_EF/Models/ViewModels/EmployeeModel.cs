using DataModel_EF.Models.Data;
using DataModel_EF.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel_EF.Models.ViewModels
{
    public class EmployeeModel
    {
        public Employee Employee { get; set; }
        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Type { get; set; }
        public List<ManagerDTO> ManagerList { get; set; }
        public List<CountryDTO> CountryList { get; set; }
        public List<DegreeDTO> DegreeList { get; set; }
    }
}
