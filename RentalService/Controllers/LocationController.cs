using Microsoft.AspNetCore.Mvc;
using NetChallenge.Dto.Input;
using NetChallenge.Services;
using System.Runtime.InteropServices;

namespace RentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger,
                                  ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddLocationRequest request)
        {
            try
            {
                _locationService.AddLocation(request);
                return Ok();
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromBody] AddLocationRequest request)
        {
            try
            {
                var result = _locationService.GetLocationByLocationName(request.Name);

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
