using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class Salvo
    {
        [Key]
        public long Id { get; set; }
        public long GamePlayerId { get; set; }
        [ForeignKey("GamePlayerId")]
        public GamePlayer GamePlayer { get; set; }
        public int Turn { get; set; }
        public ICollection<SalvoLocation> Locations { get; set; }
    }
}
