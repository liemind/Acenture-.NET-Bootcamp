using System.Collections.Generic;

namespace Salvo.Models.DTO
{
    public class SalvoDTO
    {
        public long Id { get; set; }
        public int Turn { get; set; }
        public PlayerDTO player { get; set; }
        public ICollection<SalvoLocationDTO> locations { get; set; }
    }
}
