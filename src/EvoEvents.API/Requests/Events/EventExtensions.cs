using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Queries;
using Infrastructure.Utilities;

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
                Registered = request.Registered,
                Email = request.Email,
                EventType = request.EventType
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
                City = request.City,
                Country = request.Country,
                Location = request.Location,
                FromDate = request.DateRangeModel.FromDate.ToUniversalTime(),
                ToDate = request.DateRangeModel.ToDate.ToUniversalTime()
            };
        }
    }
}