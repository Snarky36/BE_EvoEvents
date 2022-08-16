using EvoEvents.Business.Events.Models;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Business.Reservations;
using EvoEvents.Business.Shared;
using EvoEvents.Business.Shared.Models;
using EvoEvents.Business.Users;
using EvoEvents.Data;
using EvoEvents.Data.Models.Events;
using EvoEvents.Data.Models.Users;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.Errors.ErrorMessages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Events.Handlers
{
    public class ViewAllEventsQueryHandler : IRequestHandler<ViewAllEventsQuery, PageInfo<EventInformation>>
    {
        private readonly EvoEventsContext _context;
        private IQueryable<Event> _events;
        private User _user;

        public ViewAllEventsQueryHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<PageInfo<EventInformation>> Handle(ViewAllEventsQuery query, CancellationToken cancellationToken)
        {
            _events = _context.Events;

            ApplyFilters(query);

            return await GetPaginatedEvents(query.PageNumber, query.ItemsPerPage);
        }

        private void ApplyFilters(ViewAllEventsQuery query)
        {
            ApplyIsRegisteredFilters(query.Email, query.Registered);

            ApplyEventTypeFilters(query.EventType);
        }

        private void ApplyIsRegisteredFilters(string email, bool registered)
        {
            if(email is null)
            {
                return;
            }

            ValidateUser(email);

            var eventIds = _context.Reservations
                    .FilterByUserId(_user.Id)
                    .Select(r => r.EventId);

            _events = _events.Where(e => eventIds.Contains(e.Id) == registered);
        }

        private void ValidateUser(string email)
        {
            _user = _context.Users.FilterByEmail(email).FirstOrDefault();

            if (_user is null)
            {
                throw new CustomException(ErrorCode.User_NotFound, UserErrorMessage.UserNotFound);
            }
        }

        private void ApplyEventTypeFilters(EventType eventType)
        {
            if (eventType is EventType.None)
            {
                return;
            }

            _events = _events.FilterByEventType(eventType);
        }

        private async Task<PageInfo<EventInformation>> GetPaginatedEvents(int pageNumber, int itemsPerPage)
        {
            var list = await _events.GetPage(pageNumber, itemsPerPage)
                .ToEventInformation(150)
                .ToListAsync();

            return new PageInfo<EventInformation>(list, _events.Count());
        }
    }
}