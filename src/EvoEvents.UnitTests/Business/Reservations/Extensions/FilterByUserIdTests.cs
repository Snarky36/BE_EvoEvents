using EvoEvents.Business.Reservations;
using EvoEvents.Data.Models.Reservations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EvoEvents.UnitTests.Business.Reservations.Extensions
{
    [TestFixture]
    public class FilterByUserIdTests
    {
        private IQueryable<Reservation> _reservations;

        [SetUp]
        public void Init()
        {
            SetupReservations();
        }

        [Test]
        public void ShouldReturnFilteredQueryable()
        {
            int userId = 1;

            var reservations = _reservations.FilterByUserId(userId);

            Assert.That(reservations.Count(), Is.EqualTo(1));
            Assert.That(reservations.FirstOrDefault().UserId, Is.EqualTo(userId));
        }

        private void SetupReservations()
        {
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id=1,
                    EventId = 1,
                    UserId = 1
                },
                new Reservation
                {
                    Id=2,
                    EventId = 3,
                    UserId = 3
                }
            };

            _reservations = reservations.AsQueryable();
        }
    }
}