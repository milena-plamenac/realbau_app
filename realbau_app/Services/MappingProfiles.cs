﻿using AutoMapper;

namespace realbau_app.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<realbau_app.api.Models.AddressDetails, realbau_app.Models.AddressDetails>();
            CreateMap<realbau_app.Models.AddressDetails, realbau_app.api.Models.AddressDetails>();
        }
    }
}
