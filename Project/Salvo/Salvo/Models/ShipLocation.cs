using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salvo.Models
{
    public class ShipLocation
    {
        [Key]
        public long Id { get; set; }
        public string Location { get; set; }
        public long ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
    }
}
