using EvoEvents.API.Requests.Events;
using EvoEvents.API.Shared.Models;
using FluentAssertions;
using NUnit.Framework;

namespace EvoEvents.UnitTests.Api.Extensions.EventExtensionsTests
{
    [TestFixture]
    public class ViewAllEventsRequestToQueryTests
    {
        [Test]
        public void ShouldReturnCorrectGetEventsQuery()
        {
            var request = new ViewAllEventsRequest
            {
                PaginationModel = new PaginationModel 
                {
                    PageNumber = 1,
                    ItemsPerPage = 4
                }
            };

            var result = request.ToQuery();

            result.PageNumber.Should().Be(request.PaginationModel.PageNumber);
            result.ItemsPerPage.Should().Be(request.PaginationModel.ItemsPerPage);
        }
    }
}