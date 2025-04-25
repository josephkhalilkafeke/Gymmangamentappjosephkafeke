using System.ComponentModel.DataAnnotations;
namespace finalprojectjosephkafekecprg211.Data
{
    public class WorkoutClassFormModel
    {
        [Required(ErrorMessage = "Class title is required")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Schedule is required")]
        [FutureDate(ErrorMessage = "Schedule must be in the future")]
        public DateTime Schedule { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Trainer is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a trainer")]
        public int TrainerID { get; set; }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTime?)value;
            if (date.HasValue && date.Value <= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}