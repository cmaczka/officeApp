using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using NetChallenge.Infrastructure;
using NetChallenge.Validations;

namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected OfficeRentalService Service;
        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;
        protected IValidate<BookOfficeRequest> ValidateBookOffice;
        protected IValidate<AddOfficeRequest> ValidateAddOffice;
        protected IValidate<AddLocationRequest> ValidateAddLocation;
        protected IValidate<SuggestionsRequest> ValidateSuggestions;

        public OfficeRentalServiceTest()
        {
            LocationRepository = new LocationRepository();
            OfficeRepository = new OfficeRepository();
            BookingRepository = new BookingRepository();
            ValidateBookOffice = new ValidateBookOffice(LocationRepository,
                                                        OfficeRepository,       
                                                        BookingRepository);
           
            ValidateAddLocation = new ValidateAddLocation(LocationRepository);

            Service = new OfficeRentalService(LocationRepository,
                                              OfficeRepository,
                                              BookingRepository,
                                              ValidateBookOffice,
                                              ValidateAddLocation);
        }
    }
}