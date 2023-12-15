using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge
{
    public interface IBookingServices
    {
        void BookOffice(BookOfficeRequest request);
        IEnumerable<BookingDto> GetBookings(string locationName, string officeName);
    }
}