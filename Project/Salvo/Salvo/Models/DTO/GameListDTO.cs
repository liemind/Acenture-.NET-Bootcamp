using System.Collections.Generic;

namespace Salvo.Models.DTO
{
    public class GameListDTO
    {
        public string Email { get; set; }
        public ICollection<GameDTO> games { get; set; }
    }
}
