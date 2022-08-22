using EvoEvents.Business.Addresses;
using EvoEvents.Business.Addresses.Models;
using EvoEvents.Data.Models.Addresses;
using FluentAssertions;
using NUnit.Framework;

namespace EvoEvents.UnitTests.Business.Addresses.Extensions
{
    [TestFixture]
    public class AddressToAddressInformationTests
    {
        private Address _address;

        [SetUp]
        public void Innit()
        {
            SetupAddress();
        }

        private void SetupAddress()
        {
            _address = new Address
            {
                Location = "Strada Bisericii Sud",
                CityCountries = new CityCountries
                {
                    CityId = (City)1,
                    CountryId = (Country)2
                }
            };
        }
        [Test]
        public void ShouldReturnCorrectAddressInformation()
        {
            var addressInformation = _address.ToAddressInformation();
            
            addressInformation.Should().BeEquivalentTo(
                new AddressInformation
                {
                    Location = _address.Location,
                    CityCountries = new CityCountries
                    {
                        CityId = (City)1,
                        CountryId = (Country)2
                    }
                });
        }
    }
}