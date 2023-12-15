using AutoMapper;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge.Services
{
    public class LocationServices : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IValidate<AddLocationRequest> _validateAddLocation;
        private readonly IMapper _mapper;


        public LocationServices(ILocationRepository locationRepository,
                                IValidate<AddLocationRequest> validateAddLocation,
                                IMapper mapper)
        { 
          
            _locationRepository = locationRepository;
            _validateAddLocation = validateAddLocation;
            _mapper = mapper;
        }

        public void AddLocation(AddLocationRequest request)
        {
            _validateAddLocation.Validate(request);

            var location = _mapper.Map<Location>(request);
            _locationRepository.Add(location);
        }

        public LocationDto GetLocationByLocationName(string locatioName)
        {
            var location = _locationRepository.GetLocationByLocationName(locatioName);
            return _mapper.Map<LocationDto>(location);
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var location = _locationRepository.GetLocations();
            return _mapper.Map<IEnumerable<LocationDto>>(location);
        }

    }
}