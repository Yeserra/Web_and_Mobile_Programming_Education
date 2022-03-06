using SimpleCore.Models.Classes;

namespace SimpleCore.Models.ViewModels
{
    public class CityModel
    {
        public CityModel()
        {
            //ilk city degisken ismi, ikinci city class ismi
            City = new City();

        }
        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public City City { get; set; }
    }
}
