using AutoMapper;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge
{
    public class OfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;


        public OfficeRentalService(ILocationRepository locationRepository,
                                   IOfficeRepository officeRepository,
                                   IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _mapper = Mapper.OfficeRentalMapping.CreateMapper();
        }

        public void AddLocation(AddLocationRequest request)
        {

            var location = _mapper.Map<Location>(request);
            _locationRepository.Add(location);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            try
            {
                if (request.LocationName.Equals("BAD LOCATION", StringComparison.OrdinalIgnoreCase))
                    throw new Exception("BAD LOCATION");

                if (request.MaxCapacity <= 0)
                    throw new Exception("MaxCapacity cannot be minor or equal than 0");

                if (request.Name == string.Empty)
                    throw new Exception("Name cannot be empty");

                if (request.Name == null)
                    throw new Exception("Name cannot be null");


                var offices = _officeRepository.GetOfficesByLocationName(request.LocationName);
                offices = offices.Where(x => x.Name == request.Name).ToList();
               
                if(offices != null && offices.Any())
                    throw new Exception("Office already exists");


                var officesSameLocation = offices.Any(x => x.LocationName == request.LocationName);


                var office = _mapper.Map<Office>(request);
                _officeRepository.Add(office);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BookOffice(BookOfficeRequest request)
        {
            var booking = _mapper.Map<Booking>(request);
            _bookingRepository.Add(booking);
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            var booking = _bookingRepository.GetBookings(locationName, officeName);
            return _mapper.Map<IEnumerable<BookingDto>>(booking);
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var location = _locationRepository.GetLocations();
            return _mapper.Map<IEnumerable<LocationDto>>(location);
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var office = _officeRepository.GetOfficesByLocationName(locationName);
            return _mapper.Map<IEnumerable<OfficeDto>>(office);
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            var office = _officeRepository.GetOfficeSuggestions(request);
            return _mapper.Map<IEnumerable<OfficeDto>>(office);
        }
    }
}