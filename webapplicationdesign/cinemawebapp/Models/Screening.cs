using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Screening
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        // FK
        [Required(ErrorMessage = "Movie is required.")]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        [Required(ErrorMessage = "Hall is required.")]
        [Display(Name = "Hall")]
        public int HallId { get; set; }
        public Hall Hall { get; set; } = null!;

        // Navigation
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}