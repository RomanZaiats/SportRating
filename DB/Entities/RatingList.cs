using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class RatingList
    {
        public RatingList()
        {
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime GeneratedDate { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
