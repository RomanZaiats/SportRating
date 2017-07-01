using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Tournament
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public int StageId { get; set; }

        public int? CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Country Country { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
