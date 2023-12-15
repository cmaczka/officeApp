using Microsoft.AspNetCore.Mvc;
using NetChallenge;

namespace RentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
      
        private readonly ILogger<BookingController> _logger;
        private readonly IOfficeServices _officeService;

        public BookingController(ILogger<BookingController> logger,
                                 IOfficeServices officeRentalService)
        {
            _logger = logger;
            _officeService = officeRentalService;
        }




    }
}
