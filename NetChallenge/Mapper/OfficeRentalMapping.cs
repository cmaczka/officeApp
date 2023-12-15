using AutoMapper;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Mapper
{
    public class OfficeRentalMapping : Profile
    {
        public OfficeRentalMapping()
        {
            CreateMap<AddLocationRequest, Location>();
            CreateMap<AddOfficeRequest, Office>();
            CreateMap<BookOfficeRequest, Booking>();
            CreateMap<Booking, BookingDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<Office, OfficeDto>();
        }
    }

}
