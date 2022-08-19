using EvoEvents.Business.Reservations.Commands;
using EvoEvents.Business.Users;
using EvoEvents.Data;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.Errors.ErrorMessages;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Reservations.Handlers
{
    public class UnregisterUserCommandHandler : IRequestHandler<UnregisterUserCommand, bool>
    {
        public EvoEventsContext _context;

        public UnregisterUserCommandHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UnregisterUserCommand request, CancellationToken cancellationToken)
        {
            ValidateEvent(request);
            ValidateUser(request);
            DeleteUser(request);

            return await _context.SaveChangesAsync() > 0;
        }

        public void DeleteUser (UnregisterUserCommand command)
        {
            var userId = _context.Users
                .FilterByEmail(command.UserEmail)
                .Select(u => u.Id)
                .FirstOrDefault();

            var reservation = _context.Reservations.Where(r => r.UserId == userId && r.EventId == command.EventId).SingleOrDefault();

            if (reservation is null)
            {
                throw new CustomException(ErrorCode.Reservation_NotFound, ReservationErrorMessage.ReservationNotFound);
            }

            _context.Reservations.Remove(reservation);
        }

        private void ValidateEvent(UnregisterUserCommand command)
        {
            var _event = _context.Events.SingleOrDefault(e => e.Id == command.EventId);

            if (_event is null)
            {
                throw new CustomException(ErrorCode.Event_NotFound, EventErrorMessage.EventNotFound);
            }
        }

        private void ValidateUser(UnregisterUserCommand command)
        {
            var _user = _context.Users.FilterByEmail(command.UserEmail).FirstOrDefault();

            if (_user is null)
            {
                throw new CustomException(ErrorCode.User_NotFound, UserErrorMessage.UserNotFound);
            }
        }
    }
}