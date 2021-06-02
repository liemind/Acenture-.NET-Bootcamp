using System;

namespace Salvo.Models.DTO
{
    public class GamePlayerDTO
    {
        public long Id { get; set; }
        public DateTime JoinDate { get; set; }
        public PlayerDTO player { get; set; }
        public double? Point { get; set; }
    }
}
