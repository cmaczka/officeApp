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
    public class OfficeServices : IOfficeServices
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IValidate<BookOfficeRequest> _validateBookOffice;
        private readonly IValidate<AddOfficeRequest> _validateOffice;
        private readonly IMapper _mapper;


        public OfficeServices(ILocationRepository locationRepository,
                                   IOfficeRepository officeRepository,
                                   IBookingRepository bookingRepository,
                                   IValidate<BookOfficeRequest> validateBookOffice,
                                   IValidate<AddOfficeRequest> validateOffice,
                                   IMapper mapper)
        {
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _validateBookOffice = validateBookOffice;
            _validateOffice = validateOffice;
            _mapper = mapper;
        }



        public void AddOffice(AddOfficeRequest request)
        {

            _validateOffice.Validate(request);

            var office = _mapper.Map<Office>(request);
            _officeRepository.Add(office);

        }

        public void BookOffice(BookOfficeRequest request)
        {
            _validateBookOffice.Validate(request);

            var booking = _mapper.Map<Booking>(request);
            _bookingRepository.Add(booking);
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