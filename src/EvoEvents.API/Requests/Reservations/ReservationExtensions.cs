using EvoEvents.Business.Reservations.Commands;

namespace EvoEvents.API.Requests.Events.Reservations
{
    public static class ReservationExtensions
    {
        public static CreateReservationCommand ToCommand(this CreateReservationRequest request)
        {
            return new CreateReservationCommand
            {
                EventId = request.EventId,
                AccompanyingPersonEmail = request.RegistrationInformation.AccompanyingPerson,
                UserEmail = request.RegistrationInformation.UserEmail
            };
        }
    }
}