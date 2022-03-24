using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string CityName { get; set; }
        public bool Deleted { get; set; }
    }
}
