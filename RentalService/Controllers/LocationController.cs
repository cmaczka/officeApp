using Microsoft.AspNetCore.Mvc;
using NetChallenge.Dto;
using NetChallenge.Dto.Input;
using NetChallenge.Services;
using System.Net;
using System.Runtime.InteropServices;

namespace RentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ApiControllerBase
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
        public IActionResult Add([FromBody] RequestDto<AddLocationRequest> request)
        {
            try
            {
                _locationService.AddLocation(request.Data);

                return CreateSuccessResponse((int)HttpStatusCode.OK, "Location added successfully");
                
            }
            catch (Exception e)
            {
                return CreateErrorResponse((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _locationService.GetLocations();

                return CreateSuccessResponse((int)HttpStatusCode.OK, result);

            }
            catch (Exception e)
            {
                return CreateErrorResponse((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("{locationName}")]
        public IActionResult Get(string locationName)
        {
            try
            {
                var result = _locationService.GetLocationByLocationName(locationName);

                return CreateSuccessResponse((int)HttpStatusCode.OK, result);

            }
            catch (Exception e)
            {
                return CreateErrorResponse((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
