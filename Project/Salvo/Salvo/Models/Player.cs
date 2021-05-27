using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class Player
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
