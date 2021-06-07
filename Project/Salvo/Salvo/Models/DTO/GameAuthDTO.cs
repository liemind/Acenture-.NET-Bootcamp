using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models.DTO
{
    public class GameAuthDTO
    {
        public string Email { get; set; }
        public IEnumerable<GameDTO> games { get; set; }
    }
}
