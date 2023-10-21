using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;

namespace UniversityLifeApp.MVC.ViewModels
{
    public class CityViewModel
    {
        public GetCityByIdResponse Response { get; set; }
        public UpdateCityRequest Request { get; set; }
    }
}
