using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTollCollection.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TollRecord")]
        public int TollRecordId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

      
        public TollRecord? TollRecord { get; set; }
    }
}
