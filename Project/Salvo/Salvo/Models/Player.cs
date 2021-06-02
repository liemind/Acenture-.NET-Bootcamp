using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Salvo.Models
{
    public class Player
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
        public ICollection<Score> Scores { get; set; }
        public Score GetScore(Game game)
        {
            return Scores.FirstOrDefault(s => s.GameId == game.Id);
        }
    }
}
