using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models.DTO
{
    public class SalvoDTO
    {
        public long Id { get; set; }
        public int Turn { get; set; }
        public PlayerDTO player { get; set; }
    }
}
