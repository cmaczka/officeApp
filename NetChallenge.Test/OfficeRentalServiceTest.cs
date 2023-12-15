using AutoMapper;
using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using NetChallenge.Infrastructure;
using NetChallenge.Mapper;
using NetChallenge.Services;
using NetChallenge.Validations;

namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected ILocationService LocationServices;
        protected IOfficeServices OfficeServices;
        protected IBookingServices BookingServices;
        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;
        protected IValidate<BookOfficeRequest> ValidateBookOffice;
        protected IValidate<AddOfficeRequest> ValidateAddOffice;
        protected IValidate<AddLocationRequest> ValidateAddLocation;
        protected IValidate<SuggestionsRequest> ValidateSuggestions;
        protected OfficeRentalServices Service;
        private IMapper mapper;

        public OfficeRentalServiceTest()
        {
            LocationRepository = new LocationRepository();
            OfficeRepository = new OfficeRepository();
            BookingRepository = new BookingRepository();
            ValidateAddLocation = new ValidateAddLocation(LocationRepository);
            ValidateAddOffice = new ValidateAddOffice(LocationRepository,
                                                      OfficeRepository);
            ValidateSuggestions = new ValidateSuggestions();
            ValidateAddOffice = new ValidateAddOffice(LocationRepository,
                                                      OfficeRepository);
                                                          


            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OfficeRentalMapping>();
            }).CreateMapper();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            LocationServices = new LocationServices(LocationRepository,
                                                    ValidateAddLocation,
                                                    mapper);

            OfficeServices = new OfficeServices(LocationRepository,
                                                OfficeRepository,
                                                BookingRepository,
                                                ValidateBookOffice,
                                                ValidateAddOffice);

            BookingServices = new BookingServices(BookingRepository,
                                                  ValidateBookOffice);

            ValidateBookOffice = new ValidateBookOffice(LocationRepository,
                                                        OfficeRepository,       
                                                        BookingRepository);

           
            ValidateAddLocation = new ValidateAddLocation(LocationRepository);

            Service = new OfficeRentalServices(LocationServices,
                                               OfficeServices,
                                               BookingServices,
                                               ValidateBookOffice,
                                               ValidateAddLocation,
                                               ValidateAddOffice,
                                               mapper);
        }
    }
}