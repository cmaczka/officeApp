using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge.Services
{
    public interface ILocationService
    {
        void AddLocation(AddLocationRequest request);
        IEnumerable<LocationDto> GetLocations();
        LocationDto GetLocationByLocationName(string locatioName);
    }
}