using EvoEvents.API.Requests.Events;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Api.Extensions.EventExtensionsTests
{
    [TestFixture]
    public class ViewEventRequestToQueryTests
    {
        [Test]
        public void ShouldReturnCorrectViewEventQuery()
        {
            var request = new ViewEventRequest
            {
                Id = 1
            };

            var result = request.ToQuery();

            result.Id.Should().Be(request.Id);
        }
    }
}