using EvoEvents.Data.Models.Reservations;
using System.Linq;

namespace EvoEvents.Business.Reservations
{
    public static class ReservationExtensions
    {
        public static IQueryable<Reservation> FilterByUserId(this IQueryable<Reservation> reservations, int userId)
        {
            return reservations.Where(r => r.UserId == userId);
        }
    }
}