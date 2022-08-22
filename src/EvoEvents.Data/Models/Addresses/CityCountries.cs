namespace EvoEvents.Data.Models.Addresses
{
    public class CityCountries
    {   
        public int Id { get; set; }
        public City CityId { get; set; }
        public Country CountryId { get; set; }

        public virtual CountryLookup Country { get; set; }
        public virtual CityLookup City { get; set; }
    }
}