using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CCTService
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public static explicit operator City(CityDto cityDto)
        {
            City cityEntity = new City()
            {
                Id = cityDto.Id,
                Name = cityDto.Name,
                CountryId = cityDto.CountryId
            };

            return cityEntity;
        }

        public static explicit operator CityDto(City cityEntity)
        {
            CityDto cityDto = new CityDto()
            {
                Id = cityEntity.Id,
                Name = cityEntity.Name,
                CountryId = cityEntity.CountryId
            };

            return cityDto;
        }
    }
}
