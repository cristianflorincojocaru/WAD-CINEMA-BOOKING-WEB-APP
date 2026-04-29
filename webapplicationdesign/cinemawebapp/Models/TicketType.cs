using System.ComponentModel.DataAnnotations;

namespace cinemawebapp.Models
{
    public class TicketType : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Minimum seats is required.")]
        [Range(1, 100, ErrorMessage = "Minimum seats must be between 1 and 100.")]
        [Display(Name = "Min Seats")]
        public int MinSeats { get; set; } = 1;

        [Required(ErrorMessage = "Maximum seats is required.")]
        [Range(1, 100, ErrorMessage = "Maximum seats must be between 1 and 100.")]
        [Display(Name = "Max Seats")]
        public int MaxSeats { get; set; } = 5;

        [StringLength(20, ErrorMessage = "Day restriction must be at most 20 characters.")]
        [Display(Name = "Day Restriction")]
        public string? DayRestriction { get; set; }

        [StringLength(50, ErrorMessage = "Emoji must be at most 50 characters.")]
        public string? Emoji { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        // 🔥 Validare custom
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinSeats > MaxSeats)
            {
                yield return new ValidationResult(
                    "Min Seats cannot be greater than Max Seats.",
                    new[] { nameof(MinSeats), nameof(MaxSeats) }
                );
            }
        }
    }
}