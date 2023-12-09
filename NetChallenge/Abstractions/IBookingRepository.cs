using NetChallenge.Domain;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetBookings(string locationName, string officeName);
    }
}