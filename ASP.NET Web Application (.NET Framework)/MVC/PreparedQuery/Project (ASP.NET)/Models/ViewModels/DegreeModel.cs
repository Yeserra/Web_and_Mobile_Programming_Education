using Project.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.ViewModels
{
    public class DegreeModel
    {
        public Degree Degree { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
    }
}
