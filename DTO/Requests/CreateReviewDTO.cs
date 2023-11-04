using System.ComponentModel.DataAnnotations;

namespace DTO.Requests
{
    public class CreateReviewDTO
    {
        public CreateReviewDTO() { }
        [Required]
        public string email { get; set; }
        [Required]
        public int bookId { get; set; }
        [Required]
        public string comment { get; set; }
        [Required]
        public int rating { get; set; }
    }
}
