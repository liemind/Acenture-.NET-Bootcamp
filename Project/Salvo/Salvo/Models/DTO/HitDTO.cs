using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models.DTO
{
    public class HitDTO
    {
        public string type { get; set; }
        public List<string> hits { get; set; }
    }
}
