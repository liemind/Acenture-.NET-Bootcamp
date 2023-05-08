using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class SalvoLocation
    {
        [Key]
        public long Id { get; set; }
        public string Cell { get; set; }
        public long SalvoId { get; set; }
        [ForeignKey("SalvoId")]
        public Salvo Salvo { get; set; }
    }
}
