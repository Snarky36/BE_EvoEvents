using EvoEvents.Data.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EvoEvents.Data.Configurations.Addresses
{
    public class CityCountriesConfiguration : IEntityTypeConfiguration<CityCountries>
    {
        public void Configure(EntityTypeBuilder<CityCountries> builder)
        {
            List<CityCountries> cityCountriesList = new List<CityCountries>
            {
                new CityCountries
                {   Id = 1,
                    CityId = (City)1,
                    CountryId = (Country)1
                },
                new CityCountries
                {
                    Id = 2,
                    CityId = (City)2,
                    CountryId = (Country)1
                },
                new CityCountries
                {   Id = 3,
                    CityId = (City)3,
                    CountryId = (Country)1
                },
                new CityCountries
                {   Id = 4,
                    CityId = (City)4,
                    CountryId = (Country)2
                },
                new CityCountries
                {   
                    Id = 5,
                    CityId = (City)5,
                    CountryId = (Country)3
                },
                new CityCountries
                {   
                    Id = 6,
                    CityId = (City)6,
                    CountryId = (Country)3
                },
                new CityCountries
                {
                    Id = 7,
                    CityId = (City)7,
                    CountryId = (Country)2
                }
            };
            builder.HasData(cityCountriesList);
        }
    }
}
