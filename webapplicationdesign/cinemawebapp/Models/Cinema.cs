using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opening hours are required.")]
        [StringLength(50, ErrorMessage = "Opening hours must be at most 50 characters.")]
        public string OpeningHours { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact is required.")]
        [StringLength(100, ErrorMessage = "Contact must be at most 100 characters.")]
        public string Contact { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "Image path must be at most 300 characters.")]
        public string? ImagePath { get; set; }

        // Navigation
        public ICollection<Hall> Halls { get; set; } = new List<Hall>();
    }
}