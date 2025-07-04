﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class RegistrationUserMappingProfile:Profile
    {
        public RegistrationUserMappingProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>().
             ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
             .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
