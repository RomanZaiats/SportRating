using AutoMapper;
using DB.Entities;
using DTOs.Api;
using DTOs.CCTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesHelper
{
    public static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CountryDto, CountryApiDto>()
                    .ReverseMap();
                config.CreateMap<CityDto, CityApiDto>()
                    .ReverseMap();
                config.CreateMap<TeamDto, TeamApiDto>()
                    .ReverseMap();
                config.CreateMap<City, CityDto>()
                    .ReverseMap();
                config.CreateMap<Team, TeamDto>()
                    .ReverseMap();
                config.CreateMap<Country, CountryDto>()
                    .ForMember("Cities", opt => opt.MapFrom(c => Mapper.Map<ICollection<City>, IEnumerable<CityDto>>(c.Cities)));
                config.CreateMap<CountryDto, Country>()
                    .ForMember("Cities", opt => opt.Ignore());
            });
        }
    }
}
