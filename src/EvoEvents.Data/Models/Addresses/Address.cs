namespace EvoEvents.Data.Models.Addresses
{
    public class Address
    {
        public int Id { get; set; } 
        public int EventId { get; set; }
        public string Location { get; set; }
        public int CityCountriesId { get; set; }

        public CityCountries CityCountries{ get; set; }
    }
}