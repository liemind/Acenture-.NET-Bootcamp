using System;
using System.Collections.Generic;

namespace Salvo.Models.DTO
{
    public class GameViewDTO
    {
        public long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<GamePlayerDTO> gamePlayers { get; set; }
        public ICollection<ShipDTO> ships { get; set; }
        public ICollection<SalvoDTO> salvos { get; set; }
        public ICollection<SalvoHitDTO> hits { get; set; }
        public ICollection<SalvoHitDTO> hitsOpponent { get; set; }
        public List<string> sunks { get; set; }
        public List<string> sunksOpponent { get; set; }
    }
}
