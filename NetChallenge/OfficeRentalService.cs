using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
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
            var locations = _locationRepository.GetLocations();
            locations = locations.Where(x => x.Name == request.Name).ToList();

            if (locations != null && locations.Any())
                throw new Exception("Location already exists");

            if(request.Name == string.Empty)
                throw new Exception("Name cannot be empty");

            if (request.Name == null)
                throw new Exception("Name cannot be null");

            if(request.Neighborhood == string.Empty)
                throw new Exception("Neighborhood cannot be empty");

            if(request.Neighborhood == null)
                throw new Exception("Neighborhood cannot be null");


            var location = _mapper.Map<Location>(request);
            _locationRepository.Add(location);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            try
            {
                var location = _locationRepository.GetLocations().FirstOrDefault(x => x.Name == request.LocationName);
                if(location == null )
                    throw new Exception("Location does not exist");

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

            var office = _officeRepository.GetOfficesByLocationName(request.LocationName).FirstOrDefault(x => x.Name  == request.OfficeName);
            
            if(office == null)
                throw new Exception("Office does not exist");


            if(request.Duration < TimeSpan.Zero)
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

            if(request.UserName == string.Empty)
                throw new Exception("UserName cannot be empty");

            if(request.UserName == null)
                throw new Exception("UserName cannot be null");



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