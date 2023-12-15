using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Output;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        public List<Location> _locations { get; set; }
        public LocationRepository()
        {
            _locations = new List<Location>();
        }
        public IEnumerable<Location> AsEnumerable()
        {
            return this._locations;
        }

        public void Add(Location item)
        { 
            this._locations.Add(item);
        }

        public IEnumerable<Location> GetLocations()
        {
           return _locations;
        }

        public Location GetLocationByLocationName(string locatioName)
        {
           return _locations.FirstOrDefault(x => x.Name == locatioName);
        }
    }
}