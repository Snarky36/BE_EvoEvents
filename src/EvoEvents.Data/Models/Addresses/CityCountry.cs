using System.Collections.Generic;

namespace EvoEvents.Data.Models.Addresses
{
    public class CityCountry
    {   
        public int Id { get; set; }
        public City CityId { get; set; }
        public Country CountryId { get; set; }

        public CityLookup City { get; set; }
        public CountryLookup Country { get; set; }
    }
}