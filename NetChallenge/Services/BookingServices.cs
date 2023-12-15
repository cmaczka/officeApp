using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IValidate<BookOfficeRequest> _validateBookOffice;
        private readonly IMapper _mapper;


        public BookingServices(IBookingRepository bookingRepository,
                                IValidate<BookOfficeRequest> validateBookOffice)
        {
            _bookingRepository = bookingRepository;
            _validateBookOffice = validateBookOffice;
            _mapper = Mapper.OfficeRentalMapping.CreateMapper();
        }


        public void BookOffice(BookOfficeRequest request)
        {
            _validateBookOffice.Validate(request);

            var booking = _mapper.Map<Booking>(request);
            _bookingRepository.Add(booking);
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            var booking = _bookingRepository.GetBookings(locationName, officeName);
            return _mapper.Map<IEnumerable<BookingDto>>(booking);
        }

    }
}