using Microsoft.Extensions.Options;
using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetChallenge.Validations
{
    public class ValidateBookOffice : IValidate<BookOfficeRequest>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;

        public ValidateBookOffice(ILocationRepository locationRepository,
                                  IOfficeRepository officeRepository,
                                  IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void Validate(BookOfficeRequest request)
        {
            var office = _officeRepository.GetOfficesByLocationName(request.LocationName).FirstOrDefault(x => x.Name == request.OfficeName);

            if (office == null)
                throw new Exception("Office does not exist");


            if (request.Duration < TimeSpan.Zero)
                throw new Exception("Duration cannot be minor than 0");

            if (request.Duration == TimeSpan.Zero)
                throw new Exception("Duration cannot be equal than 0");

            var location = _locationRepository.GetLocations().FirstOrDefault(x => x.Name == request.LocationName);
            if (location == null)
                throw new Exception("Location does not exist");


            var overlapingBookings = _bookingRepository.GetBookings(request.LocationName, request.OfficeName).
                                                        Where(x => x.DateTime < request.DateTime.Add(request.Duration) &&
                                                              x.DateTime.Add(x.Duration) > request.DateTime);

            if (overlapingBookings.Any())
                throw new Exception("Office is already booked");

            var overlapingExaclyBookings = _bookingRepository.GetBookings(request.LocationName, request.OfficeName).
                                                              Where(x => x.DateTime == request.DateTime &&
                                                                    x.Duration == request.Duration);

            if (overlapingExaclyBookings.Any())
                throw new Exception("Office is already booked");

            var overlapingInsideBookings = _bookingRepository.GetBookings(request.LocationName, request.OfficeName).
                                                              Where(x => x.DateTime > request.DateTime &&
                                                                    x.DateTime.Add(x.Duration) < request.DateTime.Add(request.Duration));

            if (overlapingInsideBookings.Any())
                throw new Exception("Office is already booked");

            var overlapingOutsideBookings = _bookingRepository.GetBookings(request.LocationName, request.OfficeName).
                                                               Where(x => x.DateTime < request.DateTime &&
                                                                     x.DateTime.Add(x.Duration) > request.DateTime.Add(request.Duration));

            var overlapingStartBookings = _bookingRepository.GetBookings(request.LocationName, request.OfficeName).
                                                                         Where(x => x.DateTime < request.DateTime &&
                                                                               x.DateTime.Add(x.Duration) > request.DateTime);

            if (overlapingStartBookings.Any())
                throw new Exception("Office is already booked");

            if (request.UserName == string.Empty)
                throw new Exception("UserName cannot be empty");

            if (request.UserName == null)
                throw new Exception("UserName cannot be null");
        }

    }
}
