using CodeFirst_EF.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models.ViewModels
{
    public class CityModel
    {
        public City City { get; set; }
        public string Title { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public string Type { get; set; }
    }
}
