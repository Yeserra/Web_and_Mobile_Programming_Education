using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.Classes
{
    public class City: Base
    {
        public City()
        {
            Employee = new HashSet<Employee>();
        }

        public string CityName { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
