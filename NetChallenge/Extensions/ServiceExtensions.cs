using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Abstractions;
using NetChallenge.Dto.Input;
using NetChallenge.Infrastructure;
using NetChallenge.Services;
using NetChallenge.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IValidate<BookOfficeRequest>, ValidateBookOffice>();
            services.AddScoped<IValidate<AddLocationRequest>, ValidateAddLocation>();
            services.AddScoped<IValidate<AddOfficeRequest>, ValidateAddOffice>();
            services.AddScoped<IValidate<SuggestionsRequest>, ValidateSuggestions>();
            services.AddScoped<ILocationService, LocationServices>();
            services.AddScoped<IOfficeServices, OfficeServices>();
            services.AddScoped<IBookingServices, BookingServices>();
        }

    }
}
