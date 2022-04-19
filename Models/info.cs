using System.ComponentModel.DataAnnotations;

namespace Medicine_Entry.Models
{
    public class info
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string medicineName { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Note { get; set; }
    }
}
