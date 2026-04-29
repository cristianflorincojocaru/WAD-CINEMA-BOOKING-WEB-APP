using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Genre must be between 2 and 50 characters.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "Age rating is required.")]
        [StringLength(10, ErrorMessage = "Age rating must be at most 10 characters.")]
        [Display(Name = "Age Rating")]
        public string AgeRating { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 2000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Director is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Director name must be between 2 and 100 characters.")]
        public string Director { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "Image path must be at most 300 characters.")]
        [Display(Name = "Image Path")]
        public string? ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Trailer URL must be at most 500 characters.")]
        [Url(ErrorMessage = "Trailer URL must be a valid URL.")]
        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Display(Name = "Coming Soon")]
        public bool IsUpcoming { get; set; } = false;

        // Navigation
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}