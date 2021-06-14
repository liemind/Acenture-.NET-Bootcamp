using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models.DTO
{
    public class SalvoHitDTO
    {
        public int turn { get; set; }
        public List<HitDTO> hits { get; set; }
    }
}
