using System.ComponentModel.DataAnnotations;

namespace DTO.Requests
{
    public class CreateReviewDTO
    {
        public CreateReviewDTO() { }
        [Required]
        public string email;
        [Required]
        public int bookId;
        [Required]
        public string comment;
        [Required]
        public int rating;
    }
}
