﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
