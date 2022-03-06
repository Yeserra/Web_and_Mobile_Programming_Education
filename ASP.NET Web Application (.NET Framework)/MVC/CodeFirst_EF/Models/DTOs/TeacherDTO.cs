using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityName { get; set; }
        public string MotherName { get; set; }
    }
}
