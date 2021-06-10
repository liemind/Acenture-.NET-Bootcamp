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
        public ICollection<HitDTO> hits { get; set; }
        public ICollection<HitDTO> hitsOpponent { get; set; }
        public ICollection<SunkDTO> sunks { get; set; }
        public ICollection<SunkDTO> sunksOpponent { get; set; }
    }
}
