using EvoEvents.Business.Events.Models;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Business.Shared;
using EvoEvents.Business.Shared.Models;
using EvoEvents.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Events.Handlers
{
    public class ViewAllEventsQueryHandler : IRequestHandler<ViewAllEventsQuery, PageInfo<EventInformation>>
    {
        private readonly EvoEventsContext _context;

        public ViewAllEventsQueryHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<PageInfo<EventInformation>> Handle(ViewAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await GetEventsList(request);
            var totalNoItems = _context.Events.Count();

            return new PageInfo<EventInformation>(events, totalNoItems);
        }

        private async Task<List<EventInformation>> GetEventsList(ViewAllEventsQuery request)
        {
            return await _context.Events
                .GetPage(request.PageNumber, request.ItemsPerPage)
                .ToEventInformation(150)
                .ToListAsync();
        }
    }
}