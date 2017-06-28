using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public int TeamId { get; set; }

        public int? RatingListId { get; set; }

        public double Value { get; set; }

        public virtual Team Team { get; set; }

        public virtual RatingList RatingList { get; set; }
    }
}
