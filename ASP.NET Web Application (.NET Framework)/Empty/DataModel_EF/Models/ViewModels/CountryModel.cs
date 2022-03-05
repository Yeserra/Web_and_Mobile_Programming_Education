using DataModel_EF.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel_EF.Models.ViewModels
{
    public class CountryModel
    {
        public Country Country { get; set; }
        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Type { get; set; }
    }
}
