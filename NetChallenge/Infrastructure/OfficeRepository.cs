using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;

namespace NetChallenge.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {

        private readonly List<Office> _offices = new List<Office>();

        public IEnumerable<Office> AsEnumerable()
        {
            return _offices;
        }

        public void Add(Office item)
        {
           _offices.Add(item);
        }

        public IEnumerable<Office> GetOfficesByLocationName(string locationName)
        {
            return _offices.FindAll(o => o.LocationName == locationName);
        }

        public IEnumerable<Office> GetOfficeSuggestions(SuggestionsRequest request)
        {

            var response = new List<Office>();

            var suggestionsLocation = _offices.FindAll(o => o.LocationName.Contains(request.PreferedNeigborHood));

            if (suggestionsLocation == null || !suggestionsLocation.Any())
            {
                //search other locations
                suggestionsLocation = _offices.FindAll(o => o.LocationName != request.PreferedNeigborHood);
            }



            var suggestionsCapacity = _offices.FindAll(o => o.MaxCapacity == request.CapacityNeeded);

            if (suggestionsCapacity == null || !suggestionsCapacity.Any())
            {
                //search other with bigger capacity
                suggestionsCapacity = _offices.FindAll(o => o.MaxCapacity > request.CapacityNeeded).
                                              AsEnumerable().OrderBy(x => x.MaxCapacity - request.CapacityNeeded).
                                              ToList();
            }

            var suggestionsResources = _offices.FindAll(o => o.AvailableResources.Count() == 
                                                        request.ResourcesNeeded.Count());

            if (suggestionsResources == null && !suggestionsResources.Any())
            {
                suggestionsResources = _offices.FindAll(o =>
                                                    o.AvailableResources.Count() >= request.ResourcesNeeded.Count() &&
                                                    o.AvailableResources.Intersect(request.ResourcesNeeded).Count() ==
                                                                                   request.ResourcesNeeded.Count()).
                                            AsEnumerable().OrderBy(x => x.AvailableResources.Count()).
                                            ToList();
            }
                                    
            
            var res = response.Union(suggestionsLocation).
                               Union(response.ToList()).
                               Union(response.ToList());

            return res;
                                    
        }
    }
}