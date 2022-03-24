using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.Classes
{
    public class Employee: Base
    {
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")] //ForeignKey "City City"'den yukarıda bulunmalıdır!
        public City City { get; set; }
    }
}
