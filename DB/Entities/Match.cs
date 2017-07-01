using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Match
    {
        public int Id { get; set; }

        [Required]
        public int TournamentId { get; set; }

        [Required]
        public int Team1Id { get; set; }

        [Required]
        public int Team2Id { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public DateTime Date { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Team Team2 { get; set; }
    }
}
