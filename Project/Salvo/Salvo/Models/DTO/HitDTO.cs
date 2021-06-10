using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models.DTO
{
    public class HitDTO
    {
        public int turn { get; set; }
        public ICollection<ShipLocation> hits { get; set; }
    }
}
