using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepositorySoftDelete.Models.Classes
{
    abstract public class Base
    {
        [Key]
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
