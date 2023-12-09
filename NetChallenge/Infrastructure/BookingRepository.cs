using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Output;

namespace NetChallenge.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new List<Booking>();

        public IEnumerable<Booking> AsEnumerable()
        {
            return _bookings;
        }

        public void Add(Booking item)
        {
            _bookings.Add(item);    
        }

        public IEnumerable<Booking> GetBookings(string locationName, string officeName)
        {
            return _bookings.FindAll(b => b.LocationName == locationName && b.OfficeName == officeName);
        }
    }
}