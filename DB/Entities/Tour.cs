using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public int TournamentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
