using SimpleCore.Models.Classes;
using System.Collections.Generic;

namespace SimpleCore.Models.ViewModels
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            Employee = new Employee();
        }

        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public Employee Employee { get; set; }
        public List<City> CityList { get; set; }
    }
}
