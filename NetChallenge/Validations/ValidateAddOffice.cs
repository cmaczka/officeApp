using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using NetChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetChallenge.Validations
{
    public class ValidateAddOffice : IValidate<AddOfficeRequest>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;

        public ValidateAddOffice(ILocationRepository locationRepository,
                                 IOfficeRepository officeRepository)
        {
            this._locationRepository = locationRepository;
            this._officeRepository = officeRepository;
        }


        public void Validate(AddOfficeRequest request)
        {
            var location = _locationRepository.GetLocations().FirstOrDefault(x => x.Name == request.LocationName);
            if (location == null)
                throw new Exception("Location does not exist");

            if (request.MaxCapacity <= 0)
                throw new Exception("MaxCapacity cannot be minor or equal than 0");

            if (request.Name == string.Empty)
                throw new Exception("Name cannot be empty");

            if (request.Name == null)
                throw new Exception("Name cannot be null");


            var offices = _officeRepository.GetOfficesByLocationName(request.LocationName);
            offices = offices.Where(x => x.Name == request.Name).ToList();

            if (offices != null && offices.Any())
                throw new Exception("Office already exists");


            var officesSameLocation = offices.Any(x => x.LocationName == request.LocationName);
        }
    }
}
