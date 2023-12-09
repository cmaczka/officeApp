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
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddLocationRequest, Location>();
                cfg.CreateMap<AddOfficeRequest, Office>();
                cfg.CreateMap<BookOfficeRequest, Booking>();
                cfg.CreateMap<Booking, BookingDto>();
                cfg.CreateMap<Location, LocationDto>();
                cfg.CreateMap<Office, OfficeDto>();
            }).CreateMapper();
        }
    }
}
