using EvoEvents.Data.Models.Addresses;

namespace EvoEvents.Business.Addresses.Models
{
    public class AddressInformation
    {
        public string Location { get; set; }
        public CityCountries CityCountries { get; set; }
    }
}