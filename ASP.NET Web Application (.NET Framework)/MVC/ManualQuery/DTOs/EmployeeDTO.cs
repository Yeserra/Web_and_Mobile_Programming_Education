using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManualQuery.DTOs
{
    public class EmployeeDTO //Data Transfer Object
    {
        public int EmployeeId { get; set; }
        public string Name_Surname { get; set; }
        public string Residence { get; set; }
        public string Nationality { get; set; }
        public string Manager { get; set; }
    }
}
