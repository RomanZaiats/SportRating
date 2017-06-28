using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
