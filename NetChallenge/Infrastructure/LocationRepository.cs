using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        public List<Location> Locations { get; set; }
        public LocationRepository()
        {
            Locations = new List<Location>();
        }
        public IEnumerable<Location> AsEnumerable()
        {
            return this.Locations;
        }

        public void Add(Location item)
        { 
            this.Locations.Add(item);
        }
    }
}