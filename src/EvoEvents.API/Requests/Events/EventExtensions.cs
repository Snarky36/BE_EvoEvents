using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Data.Models.Events;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EvoEvents.API.Requests.Events
{
    public static class EventExtensions
    {
        public static ViewEventQuery ToQuery(this ViewEventRequest request)
        {
            return new ViewEventQuery
            {
                Id = request.Id
            };
        }

        public static ViewAllEventsQuery ToQuery(this ViewAllEventsRequest request)
        {
            return new ViewAllEventsQuery
            {
                PageNumber = request.PaginationModel.PageNumber,
                ItemsPerPage = request.PaginationModel.ItemsPerPage,
                Attending = request.Filters != null ? request.Filters.Attending : false,
                Email = request.Filters?.Email,
                EventType = request.Filters != null ? request.Filters.EventType : EventType.None
            };
        }

        public static CreateEventCommand ToCommand(this CreateEventRequest request)
        {   
            return new CreateEventCommand
            {
                EventType = request.EventType,
                Name = request.Name,
                Description = request.Description.NullIfEmpty(),
                MaxNoAttendees = request.MaxNoAttendees,
                CityCountriesId = request.CityCountriesId,
                EventImage = request.EventImage.FileToByteArray(),
                Location = request.Location,
                FromDate = request.DateRangeModel.FromDate.ToUniversalTime(),
                ToDate = request.DateRangeModel.ToDate.ToUniversalTime()
            };
        }

        public static byte[] FileToByteArray(this IFormFile file)
        {
            using(var memoryStream = new MemoryStream())
            {   
                if(file is not null)
                {
                    file.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
                return null;
            }
        }
    }
}