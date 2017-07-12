using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CCTService
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public static explicit operator Team(TeamDto teamDto)
        {
            Team teamEntity = new Team()
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                CityId = teamDto.CityId
            };

            return teamEntity;
        }

        public static explicit operator TeamDto(Team teamEntity)
        {
            TeamDto teamDto = new TeamDto()
            {
                Id = teamEntity.Id,
                Name = teamEntity.Name,
                CityId = teamEntity.CityId
            };

            return teamDto;
        }
    }
}
