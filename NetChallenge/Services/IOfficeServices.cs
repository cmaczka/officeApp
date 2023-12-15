using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Collections.Generic;

namespace NetChallenge
{
    public interface IOfficeServices
    {
        void AddOffice(AddOfficeRequest request);
        void BookOffice(BookOfficeRequest request);
        IEnumerable<OfficeDto> GetOffices(string locationName);
        IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request);
    }
}