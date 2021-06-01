using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class Score
    {
        [Key]
        public long Id { get; set; }
        public double Point { get; set; }
        public DateTime FinishDate { get; set; }
        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public long PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

    }
}
