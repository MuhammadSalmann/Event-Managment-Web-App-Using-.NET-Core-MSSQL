using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Event { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Tickets Cannot be Negative")]
        public int Tickets { get; set; }
    }
}
