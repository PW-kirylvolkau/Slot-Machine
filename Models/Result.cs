using System.ComponentModel.DataAnnotations;

namespace Slot.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstResult { get; set; }

        [Required]
        public string SecondResult { get; set; }

        [Required]
        public string ThirdResult { get; set; }
    }
}