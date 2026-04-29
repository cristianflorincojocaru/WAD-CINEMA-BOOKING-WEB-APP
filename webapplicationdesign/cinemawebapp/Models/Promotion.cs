using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emoji is required.")]
        [StringLength(50, ErrorMessage = "Emoji must be at most 10 characters.")]
        public string Emoji { get; set; } = string.Empty;

        [Required(ErrorMessage = "Discount percent is required.")]
        [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01% and 100%.")]
        [Display(Name = "Discount (%)")]
        public decimal DiscountPercent { get; set; }

        [Required(ErrorMessage = "Valid from date is required.")]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Valid until date is required.")]
        [Display(Name = "Valid Until")]
        public DateTime ValidUntil { get; set; }

        [StringLength(50, ErrorMessage = "Linked ticket type must be at most 50 characters.")]
        [Display(Name = "Linked Ticket Type")]
        public string? LinkedTicketType { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}