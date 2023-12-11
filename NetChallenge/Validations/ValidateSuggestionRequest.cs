using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Validations
{
    public class ValidateSuggestionRequest : IValidate<SuggestionsRequest>
    {
        public void Validate(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
