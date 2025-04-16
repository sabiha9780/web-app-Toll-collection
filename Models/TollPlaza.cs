using System.ComponentModel.DataAnnotations;

namespace WebAppTollCollection.Models
{
    public class TollPlaza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

     
        public IList<TollRecord> TollRecords { get; set; } = new List<TollRecord>();
    }
}
