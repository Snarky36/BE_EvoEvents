using EvoEvents.Business.Events.Models;
using EvoEvents.Business.Shared;
using EvoEvents.Business.Shared.Models;
using MediatR;

namespace EvoEvents.Business.Events.Queries
{
    public class ViewAllEventsQuery : IRequest<PageInfo<EventInformation>>
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
    }
}