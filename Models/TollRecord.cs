using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTollCollection.Models
{
    public class TollRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [ForeignKey("TollPlaza")]
        public int TollPlazaId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        // Navigation properties
        public Vehicle? Vehicle { get; set; }
        public TollPlaza ?TollPlaza { get; set; }

        
        public IList<Payment>? Payments { get; set; }=new List<Payment>();
    }
}
