using CodeFirst_EF.Models.Data;
using CodeFirst_EF.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models.ViewModels
{
    public class TeacherModel
    {
        public Teacher Teacher { get; set; }
        public string Title { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public string Type { get; set; }
        public List<CityDTO> CityList { get; set; }
    }
}
