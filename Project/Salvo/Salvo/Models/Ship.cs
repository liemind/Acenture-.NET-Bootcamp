using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class Ship
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public long GamePlayerId { get; set; }
        [ForeignKey("GamePlayerId")]
        public GamePlayer GamePlayer { get; set; }
        public ICollection<ShipLocation> Locations { get; set; }
    }
}
