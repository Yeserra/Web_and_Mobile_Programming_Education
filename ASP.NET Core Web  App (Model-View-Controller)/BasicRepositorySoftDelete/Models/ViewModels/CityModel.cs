using BasicRepositorySoftDelete.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.ViewModel
{
    public class CityModel
    {
        public CityModel()
        {
            City = new City();
        }
        public City City { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Title { get; set; }
    }
}
