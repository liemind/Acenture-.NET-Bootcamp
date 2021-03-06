using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Salvo.Models
{
    public class Player
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
