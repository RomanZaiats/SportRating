using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CCTService
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CityDto> Cities { get; set; }

        public static explicit operator Country(CountryDto countryDto)
        {
            Country countryEntity = new Country()
            {
                Id = countryDto.Id,
                Name = countryDto.Name
            };

            return countryEntity;
        }

        public static explicit operator CountryDto(Country countryEntity)
        {
            CountryDto countryDto = new CountryDto()
            {
                Id = countryEntity.Id,
                Name = countryEntity.Name,
                Cities = countryEntity.Cities.Select(i => (CityDto)i).ToList()
            };

            return countryDto;
        }
    }
}
