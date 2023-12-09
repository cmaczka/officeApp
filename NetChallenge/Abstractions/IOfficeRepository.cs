using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface IOfficeRepository : IRepository<Office>
    {
        IEnumerable<Office> GetOfficesByLocationName(string locationName);
        IEnumerable<Office> GetOfficeSuggestions(SuggestionsRequest request);
    }
}