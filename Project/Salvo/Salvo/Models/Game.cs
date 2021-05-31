using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Salvo.Models
{
    public class Game
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        public ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
