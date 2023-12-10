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
            List<Office> suggestionsCapacity= new List<Office>();

            var response = new List<Office>();
            var suggestionsLocation = _offices.Where(o => o.LocationName?.Contains(request.PreferedNeigborHood==null ? "": request.PreferedNeigborHood) ??false).ToList();
            suggestionsCapacity = suggestionsLocation.Where(o => o.MaxCapacity >= request.CapacityNeeded).OrderBy(o=>o.MaxCapacity).ToList();

            var suggestionsLocationB = _offices.Except(suggestionsLocation).Where(o=>o.MaxCapacity>=request.CapacityNeeded).OrderBy(o=>o.MaxCapacity).ToList();


            suggestionsCapacity.AddRange(suggestionsLocationB);

            var result = suggestionsCapacity.Where(p => request.ResourcesNeeded.All(p2 => p2.ToString() == p.AvailableResources.ToString())).OrderBy(p=>p.AvailableResources.Count());

            return result;
                                    
        }
    }
}