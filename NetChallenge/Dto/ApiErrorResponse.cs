using System.Collections.Generic;

namespace RentalService.Controllers
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse()
        {
        }

        public int Status { get; set; }
        public List<ApiError> Errors { get; set; }
    }
}