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
    }
}
