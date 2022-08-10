using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Models;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Data;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Events.Handlers
{
    public class ViewEventQueryHandler : IRequestHandler<ViewEventQuery, EventInformation>
    {
        private readonly EvoEventsContext _context;

        public ViewEventQueryHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<EventInformation> Handle(ViewEventQuery query, CancellationToken cancellationToken)
        {
            var eventInformation = await GetEventInformation(query);

            ValidateEventId(eventInformation);

            return eventInformation;
        }

        private async Task<EventInformation> GetEventInformation(ViewEventQuery query)
        {
            return await _context.Events
                .FilterById(query.Id)
                .ToEventInformation()
                .FirstOrDefaultAsync();
        }

        private static void ValidateEventId(EventInformation eventInformation)
        {
            if (eventInformation == null)
            {
                throw new CustomException(ErrorCode.Event_NotFound, ErrorMessage.IdNotFoundError);
            }
        }
    }
}