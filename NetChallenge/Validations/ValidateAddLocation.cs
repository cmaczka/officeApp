using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetChallenge.Validations
{
    public class ValidateAddLocation : IValidate<AddLocationRequest>
    {

        private readonly ILocationRepository _locationRepository;

        public ValidateAddLocation(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Validate(AddLocationRequest request)
        {
            var locations = _locationRepository.GetLocations();
            locations = locations.Where(x => x.Name == request.Name).ToList();

            if (locations != null && locations.Any())
                throw new Exception("Location already exists");

            if (request.Name == string.Empty)
                throw new Exception("Name cannot be empty");

            if (request.Name == null)
                throw new Exception("Name cannot be null");

            if (request.Neighborhood == string.Empty)
                throw new Exception("Neighborhood cannot be empty");

            if (request.Neighborhood == null)
                throw new Exception("Neighborhood cannot be null");
        }
    }
}
