using System.Collections.Generic;

namespace Salvo.Models.DTO
{
    public class SalvoHitDTO
    {
        public int turn { get; set; }
        public List<HitDTO> hits { get; set; }
    }
}
