using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hall name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Hall name must be between 1 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000.")]
        public int Capacity { get; set; }

        // FK
        [Required(ErrorMessage = "Cinema is required.")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;

        // Navigation
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}