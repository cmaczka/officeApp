using AutoMapper;
using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Services;
using System.Collections.Generic;

namespace NetChallenge
{
    public class OfficeRentalServices
    {
        private readonly ILocationService _locationService;
        private readonly IOfficeServices _officeService;
        private readonly IBookingServices _bookingService;
        private readonly IValidate<BookOfficeRequest> _validateBookOffice;
        private readonly IValidate<AddLocationRequest> _validateAddLocation;
        private readonly IValidate<AddOfficeRequest> _validateOffice;
        private readonly IMapper _mapper;


        public OfficeRentalServices(ILocationService locationService,
                                    IOfficeServices officeService,
                                    IBookingServices bookingService,
                                    IValidate<BookOfficeRequest> validateBookOffice,
                                    IValidate<AddLocationRequest> validateAddLocation,
                                    IValidate<AddOfficeRequest> validateOffice, 
                                    IMapper mapper)
        {
            _locationService = locationService;
            _officeService = officeService;
            _bookingService = bookingService;
            _validateBookOffice = validateBookOffice;
            _validateAddLocation = validateAddLocation;
            _validateOffice = validateOffice;
            _mapper = mapper;
        }

        public void AddLocation(AddLocationRequest request)
        {
            _locationService.AddLocation(request);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            _officeService.AddOffice(request);
        }

        public void BookOffice(BookOfficeRequest request)
        {
            _bookingService.BookOffice(request);
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            var booking = _bookingService.GetBookings(locationName, officeName);
            return _mapper.Map<IEnumerable<BookingDto>>(booking);
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var location = _locationService.GetLocations();
            return _mapper.Map<IEnumerable<LocationDto>>(location);
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var office = _officeService.GetOffices(locationName);
            return _mapper.Map<IEnumerable<OfficeDto>>(office);
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            var office = _officeService.GetOfficeSuggestions(request);
            return _mapper.Map<IEnumerable<OfficeDto>>(office);
        }
    }
}