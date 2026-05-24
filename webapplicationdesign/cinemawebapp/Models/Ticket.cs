
using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Seat number is required.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Seat number must be between 1 and 10 characters.")]
        [Display(Name = "Seat Number")]
        public string SeatNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ticket type is required.")]
        [StringLength(50, ErrorMessage = "Ticket type must be at most 50 characters.")]
        [Display(Name = "Ticket Type")]
        public string TicketType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Purchased At")]
        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;

        // FK
        [Required(ErrorMessage = "Screening is required.")]
        [Display(Name = "Screening")]
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = null!;

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Customer name must be between 1 and 100 characters.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}