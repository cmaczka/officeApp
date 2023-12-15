using Microsoft.AspNetCore.Mvc;
using NetChallenge.Dto;

namespace RentalService.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public static IActionResult CreateSuccessResponse<T>(int statusCode, T data)
        {
            var response = new ApiSuccessResponse<T>()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }

        public static IActionResult CreateErrorResponse(int statusCode, params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                Status = statusCode,
                Errors = new List<ApiError>()
            };

            foreach (var error in errors)
            {
                response.Errors.Add(new ApiError { Message = error, Code = statusCode.ToString() });
            }

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }
    }
}