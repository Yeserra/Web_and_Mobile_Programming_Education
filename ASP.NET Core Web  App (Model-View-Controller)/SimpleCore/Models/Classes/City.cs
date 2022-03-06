using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCore.Models.Classes
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required,
            StringLength(60, MinimumLength = 3, ErrorMessage = "{0} alanı en fazla {1} karakter en az {2} karakter içermelidir."),
            Display(Name = "City Name"),]

        public string CityName { get; set; }
        public string Picture { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
