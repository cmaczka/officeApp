using NetChallenge.Domain;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByLocationName(string locatioName);
        IEnumerable<Location> GetLocations();
    }
}