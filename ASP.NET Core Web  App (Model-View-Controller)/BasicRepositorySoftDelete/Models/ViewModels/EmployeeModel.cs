using BasicRepositorySoftDelete.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.ViewModel
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            Employee = new Employee();
        }

        public Employee Employee { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Title { get; set; }
        public List<City> CityList { get; set; }
    }
}
